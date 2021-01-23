        static void Main(string[] args)
        {
            List<int> Factors = new List<int> { 2, 5, 5, 7, 2, 3, 2, 9, 8, 9, 11, 9, 12, 9, 13, 9 };
            Hashtable ht = new Hashtable();
            foreach (var item in Factors)
            {
                if (ht.ContainsKey(item))
                {
                    ht[item] = Convert.ToInt32(ht[item]) + 1;
                }
                else
                    ht.Add(item, 1);
            }
            foreach (var item in ht.Keys)
            {
                if (Convert.ToInt32(ht[item]) == 1)
                Console.WriteLine(item.ToString());
            }
        }
