    var dictionaries = new JavaScriptSerializer()
                           .Deserialize<List<dictionaryNames>>(json);
---
    public class dictionaryNames
    {
        public string dictionaryName { get; set; }
        public string dictionaryCode { get; set; }
        public string dictionaryUrl { get; set; }
    }
