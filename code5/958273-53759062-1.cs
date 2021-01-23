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
