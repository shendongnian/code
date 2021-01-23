        Dictionary<string, string> rct3Features = new Dictionary<string, string>();
        Dictionary<string, string> rct4Features = new Dictionary<string, string>();
        foreach (string line in rct3Lines) 
        {
            string[] items = line.Split(new String[] { " " }, 2, StringSplitOptions.None);
            if (!rct3Features.ContainsKey(items[0]))
            {
                rct3Features.Add(items[0], items[1]);
            }
            ////To print out the dictionary (to see if it works)
            //foreach (KeyValuePair<string, string> item in rct3Features)
            //{
            //    Console.WriteLine(item.Key + " " + item.Value);
            //}
        }
