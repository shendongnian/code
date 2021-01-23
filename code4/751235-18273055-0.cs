    class Program
    {
        private static Dictionary<string, string> myDictionary;
        static void Main(string[] args)
        {
            // initialize your dictionary
            myDictionary = new Dictionary<string, string>(); 
            // fill the dictionary
            // you should fill if from file or database or something!
            myDictionary.Add("my", "mera");
            myDictionary.Add("is", "hai");
            myDictionary.Add("name", "naam");
            
            // the line you want to define in english:
            string line = "my name is Shamim";
            // output defined line in hindi:
            string output = EngLineToHindi(line);
            Console.WriteLine(output);
            Console.ReadKey();
        }
        static string EngLineToHindi(string line)
        {
            // array of words:
            string[] words = line.Split(' ');
            string ToReturn = "";
            foreach (string word in words)
            {
                string temp = EngToHindi(word) + " ";
                ToReturn += temp;
            }
            return ToReturn;
        }
        static string EngToHindi(string EngWord)
        {
            string key1 = EngWord;
            // if not has the meaning return the same word!
            if (!myDictionary.ContainsKey(key1)) return EngWord;
            else return myDictionary[key1];
        }
    }
