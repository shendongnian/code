    public class Tour
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public string City{get;set;}
    }
    
    public Dictionary<int,object> GetDictionary(string KeyName, List<object> list)
    {
        var dictionary  = Dictionary<int,object>();
        foreach(var obj in list>
        {
             dictionary.Add(GetPropValue(obj,KeyName);
        }
        return dictionary;
    }
    
    public object GetPropValue(object src, string propName)
    {
         return src.GetType().GetProperty(propName).GetValue(src, null);
    }
