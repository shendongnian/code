    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "item1");
            dictionary.Add(2, "item2");
            dictionary.Add(3, "item3");
            dictionary.Add(4, "item4");
    
            Dictionary<int, string> sortedDic = ResortDictionary(dictionary, 1, 4);
    
            foreach (KeyValuePair<int, string> row in sortedDic)
            {
                Console.WriteLine("Key: " + row.Key + "  Value: " + row.Value);
            }
    
            Console.ReadLine();
        }
    
        public static Dictionary<int, string> ResortDictionary(Dictionary<int, string> dictionary, int oldOrderNumber, int newOrderNumber)
        {
            string oldOrderNumberValue = dictionary[oldOrderNumber];
            string newOrderNumberValue = dictionary[newOrderNumber];
    
            dictionary[newOrderNumber] = oldOrderNumberValue;
            dictionary[oldOrderNumber] = newOrderNumberValue;
    
            return dictionary;
        }
    }
