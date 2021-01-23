    class Program
    {
        // declare test data
        public static int[] _products = new int[] { 1, 2, 3, 4, 5 };
        
        // Searchable value dictionary to be filled by file
        static Dictionary<int,Values> d = new Dictionary<int,Values>();      
        static void Main(string[] args)
        {
            // Read the file line by line into the dictionary          
            string line;
            System.IO.StreamReader file =
               new System.IO.StreamReader("c:\\test\\test.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] values = line.Split(',');
                int productId = int.Parse(values[0]);
                Values v = new Values();
                v.Value1 = values[1];
                v.Value2 = values[2];
                d.Add(productId, v);
            }
            file.Close();
            // check our loaded config file
            foreach (int p in _products)
            {
                
                if (d.Keys.Contains(p))
                {
                    // we've found a match in the file
                    // your logic goes here!
                }
                else
                {
                    // no match was found
                    // handle missing data
                }
            }
        }
        // struct to hold your data from text file
        struct Values
        {
            public string Value1;
            public string Value2;
        }
    }
