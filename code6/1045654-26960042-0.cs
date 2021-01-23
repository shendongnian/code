        static void Main(string[] args)
        {
            List<int> Factors = new List<int> { 2, 5, 5, 7, 2, 3 };
            Hashtable ht = new Hashtable(); 
            foreach (var item in Factors)
            {
                if (ht.ContainsKey(item))
                {
                    ht.Remove(item);
                }
                else
                ht.Add(item, 1);
            }
            foreach (var item in ht.Keys)
            {
                Console.WriteLine(item.ToString());
            }
        }
