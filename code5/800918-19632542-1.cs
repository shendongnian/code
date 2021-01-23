    using (ServiceHost serviceHost = new ServiceHost(typeof(SharePointToSQL)))
                {
                    serviceHost.Open();
    
                    foreach (var endPoints in serviceHost.Description.Endpoints)
                    {
                        Console.WriteLine(endPoints.Address);
                    }
    
                    Console.ReadKey();
                    serviceHost.Close();
                }
