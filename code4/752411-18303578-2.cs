    void Main()
    {
    	var FooList = new List<DateTime>();
    	
    	FooList.Add(DateTime.Parse("01.01.2012"));
    	FooList.Add(DateTime.Parse("01.01.2012"));
    	FooList.Add(DateTime.Parse("01.01.2012"));
    	FooList.Add(DateTime.Parse("03.03.2012"));
    	FooList.Add(DateTime.Parse("04.04.2012"));
    	FooList.Add(DateTime.Parse("04.04.2012"));
    	FooList.Add(DateTime.Parse("04.04.2012"));
    	FooList.Add(DateTime.Parse("04.04.2012"));
    	FooList.Add(DateTime.Parse("05.05.2012"));
    	FooList.Add(DateTime.Parse("05.05.2012"));
    	
    	
    	var result = FooList.GroupBy(foo => foo.Date)
    						.Select(res => new 
    							{
    								date = res.Key.DateToString("dd.MM.yyyy"), 
    								Count = res.Count()
    							})	;
    	result.DumpJson();
    }
    
    public static class MyExtensions
    {
    	public static object DumpJson(this object value, string description = null)
           {
                  return GetJsonDumpTarget(value).Dump(description);
           }    
         
           public static object DumpJson(this object value, string description, int depth)
           {
                  return GetJsonDumpTarget(value).Dump(description, depth);
           }    
         
           public static object DumpJson(this object value, string description, bool toDataGrid)
           {
                  return GetJsonDumpTarget(value).Dump(description, toDataGrid);
           }    
         
           private static object GetJsonDumpTarget(object value)
           {
                  object dumpTarget = value;
                  //if this is a string that contains a JSON object, do a round-trip serialization to format it:
                  var stringValue = value as string;
                  if (stringValue != null)
                  {
                         if (stringValue.Trim().StartsWith("{"))
                         {
                               var obj = JsonConvert.DeserializeObject(stringValue);
                               dumpTarget = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
                         }
                         else
                         {
                               dumpTarget = stringValue;
                         }
                  }
                  else
                  {
                         dumpTarget = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented);
                  }
                  return dumpTarget;
           }
    	
    }
