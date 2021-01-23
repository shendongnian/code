    public class ListWithDuplicates : List<KeyValuePair<string, string>>
    {
        public void Add(string key, string value)
        {
            var element = new KeyValuePair<string, string>(key, value);
            this.Add(element);
        }
    }
    
    var list = new ListWithDuplicates();
    list.Add("rr", "11");
    list.Add("rr", "22");
    list.Add("rr", "33");
    
    foreach(var item in list)
    {
        string x = string.format("{0}={1}, ", item.Key, item.Value);
    }
