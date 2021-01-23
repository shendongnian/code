    [ServiceContract()]
    public interface IIndexer
    {
        [OperationContract]
        bool Test();
    }
    public class Indexer : IIndexer
    {
        public bool Test()
        {
            return true;
        }
    }
        class SelfHost
        {
            static void Main(string[] args)
            {
                Uri baseAddress = new Uri("http://localhost:1234/hello");
    
                // Create the ServiceHost.
                using (ServiceHost host = new ServiceHost(typeof(Indexer), baseAddress))
                {
                    // Enable metadata publishing.
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                    host.Description.Behaviors.Add(smb);
    
                    // Open the ServiceHost to start listening for messages. Since
                    // no endpoints are explicitly configured, the runtime will create
                    // one endpoint per base address for each service contract implemented
                    // by the service.
                    host.Open();
    
                    Console.WriteLine("The service is ready at {0}", baseAddress);
                    Console.WriteLine("Press Q and <Enter> to stop the service.");
                    Console.ReadLine();
    
    
                    // Close the ServiceHost.
                    host.Close();
                }
            }
        }
