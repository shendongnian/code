	using FORREST.WebService.General;
	using FORREST.WebService.General.Modules;
	using Nancy;
	using Newtonsoft.Json;
	namespace FORREST.WebService.RESTApi.Modules
	{
		public class HelloWorldSpringRestModule : NancyModule
		{
			public string Message { get; set; }
			public string Route_Base
			{
				get { return Configuratie.Api_Root + "/Hello"; }
			}
			public HelloWorldSpringRestModule()
			{
				Get[Route_Base] = HelloSpring;
			}
			protected internal Response HelloSpring(dynamic parameters)
			{
				var _response = (Response)(JsonConvert.SerializeObject(Message));
				return _response;
			}
		}
	}
