            Dictionary<string, string> c = new Dictionary<string, string>();
            c.Add("Pk", "Pakistan");
            c.Add("Aus", "Australia");
            c.Add("Ind", "India");
            c.Add("Nz", "New Zeland");
            c.Add("SA", "South Africa");
            foreach (var v in c.Values)
            {
                if (v == "Australia")
                {
                     Console.WriteLine("Your Value is = " + v);
                    // perform your task 
                }
            }
            foreach (var k in c.Keys)
            {
                if (k == "Aus")
                {
                    // perform your task 	
                    Console.WriteLine("Your Key is = " + k);
                }
            }
