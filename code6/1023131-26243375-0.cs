    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    
    namespace ConsoleApplication1
    {
       class Program
       {
          static void Main(string[] args)
          {
    
             // Create the host on a single class
             using
             (  ServiceHost host
              = new ServiceHost
                (  typeof(MyService)
                ,  new Uri("http://localhost:1234/MyService/MyService")
                )
             ){
                // That single class could include multiple interfaces to
                //  different services, each must be added here
                host.AddServiceEndpoint
                (  typeof(IMyService)
                ,  new WSHttpBinding(SecurityMode.None)
                   // Each service can have it's own URL, but if blank use the
                   //  default above
                ,  ""
                );
                // Open the host so it can be consumed
                host.Open();
                
                // Consume the service (this cuold be in another executable)
                using
                (  ChannelFactory<IMyService> channel
                   = new ChannelFactory<IMyService>
                   (  new WSHttpBinding(SecurityMode.None)
                   ,  "http://localhost:1234/MyService/MyService"
                   )
                ){ IMyService myService = channel.CreateChannel();
                   Console.WriteLine(myService.GetValue());
                }
                
                // Clean up
                host.Close();
             }
    
    
          }
       
       }
    
       [ServiceContract]
       public interface IMyService
       {  [OperationContract] int GetValue();
       }
    
       public class MyService : IMyService
       {  public int GetValue()
          {  return 5;
          }
       }
    
    }
