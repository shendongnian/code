    using (ServiceHost host = new ServiceHost(typeof(WWWCF.Login)))
    {
         host.Open();
         Console.WriteLine("Service1 Started");
         using (ServiceHost host1 = new ServiceHost(typeof(WWWCF.UserRegistration)))
         {
                host1.Open();
                Console.WriteLine("Service2 Started");
                Console.ReadLine();
         }
    }
