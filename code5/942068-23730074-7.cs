        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<string, string> dictss = new Dictionary<string, string>();
    
                dictss.Add("onekey", "oneval");
                dictss.Add("twokey", "twoval");
                dictss.Add("threekey", "threeval");
                dictss.Add("fourkey", "fourval");
                dictss.Add("fivekey", "fiveval");
                
                string jsonString = dictss.FromDictionaryToJson(); //call extension method
    
                Console.WriteLine(jsonString);
    
                Dictionary<string, string> dictss2 = jsonString.FromJsonToDictionary(); //call extension method
    
                foreach(KeyValuePair<string,string> kv in dictss2)
                    Console.WriteLine(string.Format("key={0},value={1}", kv.Key, kv.Value));
            }
        }
