    namespace ConsoleApplication4
    {
      using System.ServiceModel; // Don't forgett to add System.ServiceModel as Reference to the Project.
      public class Program
      {
        static void Main(string[] args)
        {
          string arg = ((args != null && args.Length > decimal.Zero ? args[(int)decimal.Zero] : null) ?? string.Empty).ToLower(); // This is only reading the input for the example application, see also end of Main method.
          string randomUrl = "net.tcp://localhost:60" + new System.Random().Next(1, 100) + "/rnd" + new System.Random().Next(); // random URL to allow multiple instances parallel (for example in Unit-Tests). // Better way?
          if (arg.StartsWith("t"))
          {
            // this part could be written as a UnitTest and should be 
            string result = null;
            using (ServiceHost host = new ServiceHost(typeof(MyService)))
            {
              host.AddServiceEndpoint(typeof(IMyService), new NetTcpBinding(), randomUrl);
              host.Open();
              IMyService instance = ChannelFactory<IMyService>.CreateChannel(new NetTcpBinding(), new EndpointAddress(randomUrl), null);
              result = instance.GetIdentity();
              host.Close();
            }
            // Assert.Equals(result,"Juy Juka");
          }
          else if (arg.StartsWith("s"))
          {
            // This part runs the service and provides it to the outside. Just to show that it is a real and working host. (and not only working in a Unit-Test)
            using (ServiceHost host = new ServiceHost(typeof(MyService)))
            {
              host.AddServiceEndpoint(typeof(IMyService), new NetTcpBinding(), randomUrl);
              host.Open();
              System.Console.Out.WriteLine("Service hosted under following URL. Terminate with ENTER.");
              System.Console.Out.WriteLine(randomUrl);
              System.Console.In.ReadLine();
              host.Close();
            }
          }
          else if (arg.StartsWith("c"))
          {
            // This part consumes a service that is run/hosted outoside of the application. Just to show that it is a real and working host. (and not only working in a Unit-Test)
            System.Console.Out.WriteLine("Please enter URL of the Service. Execute GetIdentity with ENTER. Terminate with ENTER.");
            IMyService instance = ChannelFactory<IMyService>.CreateChannel(new NetTcpBinding(), new EndpointAddress(System.Console.In.ReadLine()), null);
            System.Console.Out.WriteLine(instance.GetIdentity());
            System.Console.In.ReadLine();
          }
          else
          {
            // This is only to explain the example application here.
            System.Console.Out.WriteLine("I don't understand? Please use one of the following (Terminate this instance with ENTER):");
            System.Console.Out.WriteLine("t: To host and call the service at once, like in a UnitTest.");
            System.Console.Out.WriteLine("s: To host the servic, waiting for clients.");
            System.Console.Out.WriteLine("c: To contact a hosted service and display it's GetIdenttity result.");
            System.Console.In.ReadLine();
          }
        }
      }
      // Declaration and Implementation of the Service
      [ServiceContract]
      public interface IMyService
      {
        [OperationContract]
        string GetIdentity();
      }
      public class MyService : IMyService
      {
        public string GetIdentity()
        {
          return "Juy Juka";
        }
      }
    }
