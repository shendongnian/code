        public class MyBootstrapper : Nancy.DefaultNancyBootstrapper
    	{
    		protected override void ApplicationStartup(TinyIoC.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
    		{
    			base.ApplicationStartup(container, pipelines);
    
    			pipelines.AfterRequest += ModifyModel;
    		}
    
    		private void ModifyModel(NancyContext ctx)
    		{
    			Foo foo;
    			using(var memory = new MemoryStream())
    			{
    				ctx.Response.Contents.Invoke(memory);
    
    				var str = Encoding.UTF8.GetString(memory.ToArray());
    				foo = JsonConvert.DeserializeObject<Foo>(str);
    			}
    
    			ctx.Response.Contents = stream =>
    			{
    				using (var writer = new StreamWriter(stream))
    				{
    					foo.Code = 999;
    					writer.Write(JsonConvert.SerializeObject(foo));
    				}
    			};
    		}
    	}
    
    	public class HomeModule : Nancy.NancyModule
    	{
    		public HomeModule()
    		{
    
    			Get["/"] = parameters => {
    				return Response.AsJson<Foo>(new Foo { Bar = "Bar" });
    			};
    		}
    	}
    
    	public class Foo
    	{
    		public string Bar { get; set; }
    		public int Code { get; set; }
    	}
