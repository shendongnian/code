    using System;
    using System.IO;
    using System.Collections.Generic;
    using YamlDotNet.Serialization;
    using YamlDotNet.Core;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var yaml = @"
    anchor: &default
      key1: &myValue value1
      key2: value2
    alias:
      <<: *default
      key2: Overriding key2
      key3: value3
    ";
    		
    		var reader = new EventReader(new MergingParser(new Parser(new StringReader(yaml))));
    		
    		var deserializer = new Deserializer();
    		var result = deserializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(reader);
    		
    		var alias = result["alias"];
    		Console.WriteLine("key1 = {0}", alias["key1"]);
    		Console.WriteLine("key2 = {0}", alias["key2"]);
    	}
    }
