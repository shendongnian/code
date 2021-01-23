            var set1 = new HashSet<string>();
            set1.Add("foo");
            set1.Add("foo");
            var set2 = new HashSet<string>();
            set2.Add("foo");
            var set3 = set1.Union(set2);
            foreach (var val in set3)
            {
              Console.WriteLine(val);   
            }
