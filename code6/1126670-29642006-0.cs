    static void Main(string[] args)
        {
            Dictionary<string, string> MASTERDATALIST = new Dictionary<string, string>();
            List<string> DEPARTNENTLIST = new List<string>();
            List<string> FAILEDLIST = new List<string>();
            MASTERDATALIST.Add("key1", "value1");
            MASTERDATALIST.Add("key2", "value2");
            MASTERDATALIST.Add("key3", "value3");
            MASTERDATALIST.Add("key4", "value4");
            MASTERDATALIST.Add("key5", "value5");
            DEPARTNENTLIST.Add("key1");
            DEPARTNENTLIST.Add("key2");
            DEPARTNENTLIST.Add("key3");
            foreach (KeyValuePair<string, string> item in MASTERDATALIST)
            {
                if (!DEPARTNENTLIST.Contains(item.Key))
                    FAILEDLIST.Add(item.Key);
            }
            foreach (var item in FAILEDLIST)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
