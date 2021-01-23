    using System;
    using System.Linq;
    		
    
    	public class Assembly
        {
            public int Level { get; set; }
            public string Parent { get; set; }
            public string Component { get; set; }
    		public bool Visited{get;set;} // to track visited levels
        }
    public class Program
    {
    	public static void Main()
    	{
    		        Assembly[] assemblies = { 
                new Assembly { Level=1, Parent="L010057501U", Component="231-100-002" },
                new Assembly { Level=1, Parent="L010057501U", Component="307-355-022" },
                new Assembly { Level=2, Parent="307-355-022", Component="307-355-058" },
                new Assembly { Level=2, Parent="307-355-022", Component="307-355-059" },
                new Assembly { Level=3, Parent="307-355-058", Component="355-100-008" },
                new Assembly { Level=3, Parent="307-355-059", Component="355-200-005" },
                new Assembly { Level=3, Parent="307-355-059", Component="357-100-002" },
                new Assembly { Level=3, Parent="307-355-058", Component="357-200-002" }
            };
    		DisplayAssemblies(assemblies);
    
    	}
    
        private static void DisplayAssemblies(Assembly[] data)
        {
    		// order the data to be sorted by levels
    		var levels=data.OrderBy(t=>t.Level);
    		foreach(var level in levels)
    			if(!level.Visited)
    				DisplayLevel(level,data);
            
        }
    	
    	private static void DisplayLevel(Assembly level, Assembly[] data)
    	{
    		var childs=data.Where(t=>t.Parent==level.Component).ToArray();
    		Console.WriteLine("{0} - {1} - {2}", level.Level, level.Parent, level.Component);
    		level.Visited=true;
    		foreach(var child in childs)
    		{		
    			DisplayLevel(child,data);
    		}
    	}
    }
