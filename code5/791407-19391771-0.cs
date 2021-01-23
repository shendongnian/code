		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		using System.ServiceModel;
		using System.ServiceModel.Description;
		using System.ServiceModel.Web;
		namespace SelfHost
		{
			class Program
			{
				static void Main(string[] args)
				{     
                    string localIP = "192.168.1.5";
                    string port = "8001";
					Uri baseAddress = new Uri("http://" + localIP + ":" + port + "/hello");
					
					using (ServiceHost host = new ServiceHost(typeof(HelloWorldService), baseAddress))
					{						
						ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
						smb.HttpGetEnabled = true;
						smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
						host.Description.Behaviors.Add(smb);
						host.AddServiceEndpoint(typeof(IHelloWorldService), new WebHttpBinding(), "");
						host.Description.Endpoints[0].Behaviors.Add(new WebHttpBehavior { HelpEnabled = true });                
						host.Open();
						Console.WriteLine("The service is ready at {0}", baseAddress);
						Console.WriteLine("Press <Enter> to stop the service.");
						Console.ReadLine();
						// Close the ServiceHost.
						host.Close();
					}
				}
			}
			[ServiceContract]
			public interface IHelloWorldService
			{
				[OperationContract]
				[WebGet(UriTemplate = "SayHello/{name}")]
				string SayHello(string name);
				[OperationContract]
				[WebGet(UriTemplate = "SayGoodbye/{name}")]
				string SayGoodbye(string name);
			}
			public class HelloWorldService : IHelloWorldService
			{
				public string SayHello(string name)
				{
					return string.Format("Hello, {0}", name);
				}
				public string SayGoodbye(string name)
				{
					return string.Format("Goodbye, {0}", name);
				}
			}
		}
