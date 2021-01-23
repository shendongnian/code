    using System;
    using System.Collections.Generic;
    using StructureMap;
    
    namespace StructureMapTest
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var container = new Container();
                container.Configure(x =>
                {
                    x.Scan(s =>
                    {
                        s.AssemblyContainingType<IPluginType>();
                        s.AddAllTypesOf<IPluginType>();
                    });
    
                    x.For<IMyType>().Use<MyType>();
                });
    
                var myType = container.GetInstance<IMyType>();
    			myType.PrintPlugins();
            }
        }
    	
    	public interface IMyType
        {
    		void PrintPlugins();
        }
    
        public class MyType : IMyType
        {
    		private readonly IEnumerable<IPluginType> plugins;
    
    		public MyType(IEnumerable<IPluginType> plugins)
            {
    			this.plugins = plugins;
            }
    		
    		public void PrintPlugins()
    		{
    			foreach (var item in plugins)
                {
                    item.DoSomething();
                }
    		}
        }
    	
        public interface IPluginType
        {
            void DoSomething();
        }
    
    	public class Plugin1 : IPluginType
        {
            public void DoSomething()
            {
    			Console.WriteLine("Plugin1");
            }
        }
    
        public class Plugin2 : IPluginType
        {
            public void DoSomething()
            {
                Console.WriteLine("Plugin2");
            }
        }
    }
