     static void Main()
    {
     #if DEBUG
                MailService service = new MailService();
                 service.Ondebug();
     #else
                 ServiceBase[] ServicesToRun;
                 ServicesToRun = new ServiceBase[]
                 {
                     new MailService()
                 };
                 ServiceBase.Run(ServicesToRun);
     #endif
             }
         }
    After clearing the if,else and endif in the code like this the error has not appeared again....hope it helps....
 
    static void Main()
            {
    
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new MailService()
                };
                ServiceBase.Run(ServicesToRun);
    
            }
 
