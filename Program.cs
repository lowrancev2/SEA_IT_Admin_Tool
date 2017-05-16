using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FreedomReset
{
    class Program
    {
        static void Main()
        {



            String username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            String cname;
            String serviceName1;
            String serviceName2;
            int status = 0;

            Console.WriteLine("Sea IT POS Freedom Service Reset");
            Console.WriteLine("********************************");
            Console.WriteLine("Hello, " + username + ", please enter the computer name:");

            cname = Console.ReadLine();
            String precname = cname.Substring(0, 3).ToUpper();
            serviceName1 = "FCCClientSvc";
            serviceName2 = "FCCServerSvc";

            
            
            //Create new service controllers
            var sr1 = new System.ServiceProcess.ServiceController(serviceName1, cname);
            var sr2 = new System.ServiceProcess.ServiceController(serviceName2, cname);

            //display status
            try
            {
                Console.WriteLine(sr1 + " is now " + sr1.Status);
                Console.WriteLine(sr2 + " is now " + sr2.Status);
            }
            catch
            {
                
                switch (precname)
                {
                    case "SWF":
                        System.Diagnostics.Process.Start("https://swf-dccpfw-rg.nam.int.local/connect/PortalMain");
                        break;

                    case "SWT":
                        System.Diagnostics.Process.Start("https://swt-dccpfw-rg.nam.int.local/connect/PortalMain");
                        break;

                    case "BGT":
                        System.Diagnostics.Process.Start("https://bgt-dccpfw-rg.nam.int.local/connect/PortalMain");
                        break;

                    case "BGW":
                        System.Diagnostics.Process.Start("https://bgw-dccpfw-rg.nam.int.local/connect/PortalMain");
                        break;

                    case "SWC":
                        System.Diagnostics.Process.Start("https://swc-dccpfw-rg.nam.int.local/connect/PortalMain");
                        break;

                    case "APC":
                        System.Diagnostics.Process.Start("https://apc-dccpfw-rg.nam.int.local/connect/PortalMain");
                        break;
                                               
                }

                Console.WriteLine("Are you connected through VPN?");
                Console.WriteLine("Press Enter once connected.");
                Console.ReadLine();

            }

            //Restart Services 
            try
            {
                //FCCClientSvc

                Console.WriteLine(sr1 + " is now " + sr1.Status);
                Console.WriteLine(sr2 + " is now " + sr2.Status);

                

                if (sr1.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                {
                    sr1.Stop();
                    sr1.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped);
                    sr1.Start();
                    sr1.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
                    status++;
                }
                else
                {
                    sr1.Start();
                    sr1.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
                    status++;
                }

                //FCCServerSvc
                if (sr2.Status == System.ServiceProcess.ServiceControllerStatus.Running)
                {
                    sr2.Stop();
                    sr2.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped);
                    sr2.Start();
                    sr2.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
                    status++;
                }
                else
                {
                    sr2.Start();
                    sr2.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
                    status++;
                }

            
            
            if (status != 2)
                    { 
            Console.WriteLine(sr1 + " is now " + sr1.Status);
            Console.WriteLine(sr2 + " is now " + sr2.Status);
                    Console.ReadLine();

                }
                
            else
                {
                    Console.WriteLine("There was an error. Press any key to exit.");
                    Console.ReadLine();
                    
                }

            }

            catch { Exception e; }         
                       
            
                    }

            }
}
