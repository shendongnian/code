        static void Main(string[] args)
        {
            string key = "03";
            GetValue(key);        
        }
        private static int GetValue(string key)
        {
            var lines = File.ReadAllLines("test.txt");
            var dictonary = lines.ToDictionary(dict =>
            {
                return dict.Split(',')[0];
            });          
            int valInt = int.Parse(dictonary[key].Split(',')[1]);
            return valInt; 
        }
