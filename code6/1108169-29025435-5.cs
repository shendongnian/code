    public class Program
    {
    	public static void Main()
    	{
    		ParseAndDump("First run", @"{
                ""field1"": ""my field 1"",
                ""nested"": {
                    ""num"": null,
                    ""str"": ""blah"",
                    ""dec"": 3.14
                }
            }");
    		
    		ParseAndDump("Second run", @"{
                ""field1"": ""new field value""
            }");
    		
    		ParseAndDump("Third run", @"{
                ""nested"": null
            }");
    	}
    	
    	private static void ParseAndDump(string comment, string json)
    	{
    		Console.WriteLine("--- " + comment + " ---");
    		
    		JsonSerializerSettings settings = new JsonSerializerSettings();
    		settings.Converters.Add(new DtoConverter());
    		
    		FooDTO foo = JsonConvert.DeserializeObject<FooDTO>(json, settings);
    		
    		Dump(foo, "");
    		
    		Console.WriteLine();
    	}
    	
    	private static void Dump(IHasFieldStatus dto, string indent)
    	{
    		foreach (PropertyInfo prop in dto.GetType().GetProperties())
    		{
    			if (prop.Name == "FieldStatus") continue;
    			
    			Console.Write(indent + prop.Name + ": ");
    			object val = prop.GetValue(dto);
    			if (val is IHasFieldStatus)
    			{
    				Console.WriteLine();
    				Dump((IHasFieldStatus)val, "  ");
    			}
    			else
    			{
    				FieldDeserializationStatus status = dto.FieldStatus[prop.Name];
    				if (val != null) 
    					Console.Write(val.ToString() + " ");
    				if (status != FieldDeserializationStatus.HasValue)
    					Console.Write("(" + status + ")");
    				Console.WriteLine();
    			}
    		}
    	}	
    }
