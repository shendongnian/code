    class Program
        {
            static void Main(string[] args)
            {
                var dic1 = new Dictionary<String, String>();
                dic1.Add("Key 2", "Value 2");
                dic1.Add("Key 1", "Value 1"); 
    
    
                var dic2 = new Dictionary<String, String>();
                dic2.Add("Key 1", "Value 1");
                dic2.Add("Key 2", "Value 2");
    
                var areEqual = dic1.OrderBy(r => r.Key).SequenceEqual(dic2.OrderBy(r => r.Key), new ProductComparer());
    
                Console.WriteLine(areEqual);
    
                Console.ReadLine();
            }
        }
    
        
    
        internal class ProductComparer : IEqualityComparer<KeyValuePair<string, string>>
        {
            public bool Equals(KeyValuePair<string, string> x, KeyValuePair<string, string> y)
            {
                Boolean areEqual = (String.Compare(x.Key, y.Key, StringComparison.OrdinalIgnoreCase) == 0) && (String.Compare(x.Value, y.Value, StringComparison.OrdinalIgnoreCase) == 0);
                return areEqual;
            }
    
            public int GetHashCode(KeyValuePair<string, string> obj)
            {
                return obj.GetHashCode();
            }
        }
