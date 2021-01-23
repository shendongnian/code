    public static Dictionary<string, object> Pick(object obj, Array Picklist) 
    {
        Dictionary<string, object> dic = new Dictionary<string, object> ();
        IEnumerable items = obj as IEnumerable ?? new[] { obj };
        foreach(string key in Picklist) 
        {
            foreach(object item in items)
            {
                dic.Add(key, item.GetType().GetProperty(key).GetValue(item, null));
            }
        }
        return dic;
    }
