            // Step 2 Create a ServiceHost instance to host the service
            using (ServiceHost selfHost = new ServiceHost(typeof(Service1), baseAddress)) // type of class that implements service contract, and base address of service.
            {
                try
                {
                    WebHttpBinding binding = new WebHttpBinding();
                    //BasicHttpBinding binding = new BasicHttpBinding();
                    binding.TransferMode = TransferMode.Streamed;
                    binding.MaxReceivedMessageSize = int.MaxValue; //"1000000000000"
                    binding.ReceiveTimeout = new TimeSpan(1, 0, 0); //"01:00:00";
                    binding.SendTimeout = new TimeSpan(1, 0, 0); //"01:00:00";
                    //binding.ReaderQuotas. = int.MaxValue;
                    // Step 3 Add a service endpoint to host. Endpoint consist of address, binding and service contract.
                    // Note this is optional in Framework 4.0 and upward. generate auto default.
                    selfHost.AddServiceEndpoint(typeof(IService1), binding, "").EndpointBehaviors.Add(new WebHttpBehavior()); // service contract interface, binding, address
                    // Step 5 Start the service.
                    // Open host to listen for incoming messages.
                    selfHost.Open();
                    Console.WriteLine("The service is ready.");
                    Console.WriteLine("Press <ENTER> to terminate service.");
                    Console.WriteLine();
                    Console.ReadLine();
                    // Close the ServiceHostBase to shutdown the service.
                    selfHost.Close();
                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine("An exception occurred: {0}", ce.Message);
                    selfHost.Abort();
                }
            }
           
        }
    }
