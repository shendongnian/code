            List<string> one = new List<string>();
            List<string> two = new List<string>();
            one.Add("Test 1");
            one.Add("Test 1");
            one.Add("Test 2");
            two.AddRange(one.FindAll(x => x.Contains("Test 1")));
            one.RemoveAll(x => two.Contains(x));
            Console.WriteLine("ONE:");
            foreach (string s in one)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("TWO:");
            foreach (string s in two)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
