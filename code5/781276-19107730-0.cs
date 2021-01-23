    cp.EmbeddedResources.Add("resource_files.resx"); // File local to the actual code, not the emitting code.
    ...
    string code = @"
    using System.Linq;
    
    namespace CoolThing
    {
    	public class SIQuery
    	{
    		public static void Main(string[] args)
    		{
    			var siQuery = from e in Resources.resource_files.serverSource
    						  where e % 5 == 0 select e;
    		}
    	}
    
    }";
