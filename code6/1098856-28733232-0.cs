    public class DictionaryContainer
	{
		public Dictionary<string, List<SampleObject>>  String { get; set; }
	}
	public class SampleObject
	{
		public int level { get; set; }
		public string desc { get; set; }
		public string icon { get; set; }
	}
    			
    string jsonString = "Your json string";
    var dic =  JsonConvert.DeserializeObject<DictionaryContainer>(jsonString);
