     using System.ServiceProcess;
     ...
            
            ServiceController sc = new ServiceController("MSSQLFDLauncher$MSSQLSERVER2012");
            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    Console.WriteLine("Running");
                    break;
                default:
                    Console.WriteLine("Else");
                    break;
            }
