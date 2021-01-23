    public static class Extensions
    {
        public static Dictionary<string, string> ToDicionary(this object o)
        {
            var dic = new Dictionary<string, string>();
            foreach(var property in o.GetType().GetProperties())
            {
                dic.Add(property.Name, string.Format("{0}", property.GetValue(o)));
            }
            
            return dic;
        }
    }
