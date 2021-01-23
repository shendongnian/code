    using (ServiceHost host = new ServiceHost(typeof(WWWCF.Login)))
    using (ServiceHost host1 = new ServiceHost(typeof(WWWCF.UserRegistration)))
    {
         host.Open();
         Console.WriteLine("Service1 Started");
                
         host1.Open();
         Console.WriteLine("Service2 Started");
         Console.ReadLine();
     }
