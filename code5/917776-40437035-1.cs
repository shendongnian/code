    public static class EnumHelper<T>
    {
        //to get full description list
        public static List<string> GetEnumDescriptionList()
        {
            var type = typeof(T);
            var names = Enum.GetNames(type).ToList();
    
            var list = new List<string>();
            foreach (var name in names)
            {
                var field = type.GetField(name);
                var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var temp = customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : name;                   
                list.Add(temp);
            }
            return list;
        }
       
        //for single description  
        public static string GetEnumDescription(string value)
        {
            var type = typeof(T);
            var name = Enum.GetNames(type).Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase)).Select(d => d).FirstOrDefault();
            if (name == null) return string.Empty;
            var field = type.GetField(name);
            var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : name;
        }
    }
