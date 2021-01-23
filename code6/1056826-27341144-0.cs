    using System;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System.Text;
						
	public class Program
	{
		public static void Main()
		{
				var json = @"
	{  
	   ""root"":{  
		  ""first"":{  
			 ""first1"":{  
				""value"":""1""
			 },
			 ""first2"":{  
				""value"":""2""
			 },
			 ""first3"":{  
				""value"":""3""
			 }
		  }
		}
	}";
	
			var jobject = JObject.Parse (json);
			var sb = new StringBuilder ();
			
			RecursiveParse (sb, jobject);
			
			Console.WriteLine (sb.ToString());
		}
		
		public static void RecursiveParse(StringBuilder sb, JToken token)
		{
			foreach (var item in token.Children()) {
				if (item.HasValues)
				{
					RecursiveParse (sb, item);
				} else {
					sb.AppendLine (item.Path);
				}
			}
			
		}	
	}
