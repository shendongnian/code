    void Main()
    {
	    var pl = new JsonPayload() 
		{Item1 = "Value1",Item2 = "Value2"};
	
	    var field1 = new JsonField() { Key = "Key1", Value = "Value1", OtherParam = "other1" };
	    var field2 = new JsonField() { Key = "Key2", Value = "Value2", OtherParam = "other2" };
	
	    pl.Fields = new Dictionary<string, JsonField>() { { field1.Key , field1},  { field2.Key, field2 }}; 
	
	    string json = JsonConvert.SerializeObject(pl);
	    JsonPayload pl2 = JsonConvert.DeserializeObject<JsonPayload>(json);
		
	    string output = JsonConvert.SerializeObject(pl2);
	    output.Dump();
	
    }
    public sealed class JsonField
    {
        public string Key { get; set; }
        public object Value { get; set; }
        public string OtherParam { get; set; }
    }
    public sealed class JsonPayload
    {
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public Dictionary<string, JsonField> Fields { get; set; }
    }
 
 
