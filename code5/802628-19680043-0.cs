    public class MyClass
    {
    	public void readJson)
    	{
    		var json = "{\"7407\": {\"survey_id\": \"406\",\"device_id\": \"1\",},\"7408\": {\"survey_id\": \"408\",\"device_id\": \"1\",}}";
    		Dictionary<int, MyObject> dict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, MyObject>>(json);
    		var count = dict.Keys.Count;
    	}
    }
    
    public class MyObject
    {
    	public string survey_id { get; set; }
    	public string device_id { get; set; }
    }
