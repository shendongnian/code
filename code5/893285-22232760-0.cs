	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using ClassLibrary3.MyService;
	using Microsoft.Practices.Unity;
	namespace ClassLibrary3
	{
		public class ProxyHandler
		{
			public USZipSoap iwebService { get; set; }
			public ProxyHandler(USZipSoap iWebService)
			{
				this.iwebService = iWebService;
			}
			public string GetZipInfo()
			{
				return iwebService.GetInfoByZIP("20008").InnerXml;
			}
			public static IUnityContainer BootstrapContainer()
			{
				var container = new UnityContainer();
				//Simple Registration
				//container.RegisterType<USZipSoap, USZipSoapClient>("Simple", new InjectionConstructor(new object[0]));
				//Factory registration
				container.RegisterType<USZipSoap>(new InjectionFactory(c => ProxyHandler.CreateSoapClient()));
				return container;
			}
			public static USZipSoap CreateSoapClient()
			{
				var client =  new USZipSoapClient();
				/*Configure your client */
				return client;
			}
			public static void Main()
			{
				var container = ProxyHandler.BootstrapContainer();
				var proxy2 = container.Resolve<USZipSoap>();
				var proxy1 = container.Resolve<ProxyHandler>();
				Console.WriteLine(proxy1.GetZipInfo());
				Console.ReadLine();
			}
		}    
	}
