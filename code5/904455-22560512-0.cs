    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
    	internal class Program
    	{
    		private static void Main(string[] args)
    		{
    			const string data = @"2,""E2002084700801601390870F""3,""E2002084700801601390870F""1,""E2002084700801601390870F""4,""E2002084700801601390870F""3,""E2002084700801601390870F""";
    
    			var parsedData = ParseData(data);
    
    			foreach (var parsedDatum in parsedData)
    			{
    				Console.WriteLine(parsedDatum);
    			}
    
    			Console.ReadLine();
    		}
    
    		private static IEnumerable<string> ParseData(string data)
    		{
    			var results = new List<string>();
    			var split = data.Split(new [] {'"'}, StringSplitOptions.RemoveEmptyEntries);
    
    			if (split.Length % 2 != 0)
    			{
    				throw new Exception("Data Formatting Error");
    			}
    
    			for (var index = 0; index < split.Length / 2; index += 2)
    			{
    				results.Add(string.Format(@"""{0}""{1}""", split[index], split[index + 1]));
    			}
    
    			return results;
    		}
    	}
    }
