    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    namespace t1
    {
    	class SomeClass
    	{
    		public string Prop {
    			get;
    			set;
    		}
    
    		public List<int> list = new List<int>() {1,2,3};
    	}
    
    	class SomeAnotherClass
    	{
    		public SomeClass Obj {
    			get;
    			set;
    		}
    	}
    
    	class MainClass
    	{
    		public static object GetDynamic(object o, string query) {
    			var elems = query.Split ('.');
    			var current = o;
    			var indexer = new Regex (@"(\w+)\[(\d+)\]", RegexOptions.Compiled);
    			foreach (var elem in elems)
    			{
    				var type = current.GetType ();
    				var m = indexer.Match (elem);
    				var memberName = elem;
    				int? index = null;
    				if (m.Success) {
    					memberName = m.Groups[1].Value;
    					index = int.Parse(m.Groups [2].Value);
    				}
    
    				var field = type.GetField (memberName);
    				var prop = type.GetProperty (memberName);
    				if (field != null)
    					current = field.GetValue (current);
    				else if (prop != null)
    					current = prop.GetValue (current, null);
    				else
    					throw new Exception ();
    
    				if (index.HasValue)
    				{
    					current = ((dynamic)current) [index.Value];
    				}
    			}
    			return current;
    		}
    
    		public static void Main (string[] args)
    		{
    			object o = new SomeAnotherClass ()
    			{
    				Obj = new SomeClass()
    				{
    					Prop = "asd"
    				}
    			};
    			Console.WriteLine (GetDynamic(o, "Obj.list[1]"));
    
    		}
    	}
    }
