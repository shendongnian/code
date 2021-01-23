    using System;
    using System.ServiceModel;
    
    namespace Client
    {
        class Program
        {
            static void Main(string[] args)
            {
                var cf = new ChannelFactory<Server.IService>("endpoint");
                var service = cf.CreateChannel();
                DateTimeOffset offset = service.GetOffset();
    
                Console.WriteLine(offset);
                Console.ReadLine();
            }
        }
    }
