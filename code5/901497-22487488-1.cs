            var set1 = new HashSet<string>();
            set1.Add("foo");
            set1.Add("bar");
            var set2 = new HashSet<string>();
            set2.Add("foo");
            set2.Add("baz");
            foreach (var val in set2)
            {
                set1.Remove(val);
            }
            foreach (var val in set1)
            {
                Console.WriteLine(val);    
            }
