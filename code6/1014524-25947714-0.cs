    using System.Collections.Generic;
    
    public class Program
    {
        public static void Main()
        {
            var dictionary = new Dictionary<int, Dictionary<string, string>>();
            var value = new Dictionary<string, string>();
            value.Add("Key1", "Valu1");
            dictionary.Add(1, value);
    
            Dictionary<string, string> result;
    
    
            dictionary.TryGetValue(1, out result);
    
        }
    }
