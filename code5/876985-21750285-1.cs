            string s1 = "G12A";
            string s2 = "GAA2";
            List<char> lst1 = s1.ToList();
            List<char> lst2 = s2.ToList();
            int count = 0;
            foreach (char c in lst2)
            {
                if (lst1.Contains(c))
                {
                    lst1.Remove(c);
                    count++;
                }
            }
            Console.WriteLine(count);
