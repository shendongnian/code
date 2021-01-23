    using Server;
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
                ReturnContract c = service.GetOffset();
    
                Console.WriteLine(c.Offset);
                Console.ReadLine();
            }
        }
    }
