    public class ListDictionary<T> : Dictionary<string,List<T>>
    {
        public ListDictionary():base(){}
        public void AddItem(string key, T value)
        {
            if(ContainsKey(key))
                 this[key].Add(value);
            else
                 Add(key,new List<T>{value});
        }
        //similar for remove and get
    }
