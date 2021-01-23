            string s = "August 11, 2013, 11:00:00 PM";
            string s1 = "‎August ‎11, ‎2013, ‏‎11:00:00 PM";
            char[] c = s.ToCharArray();
            char[] c1 = s1.ToCharArray();
            foreach (var ch in c)
            {
                Console.WriteLine(ch);
            }
            foreach (var ch1 in c1)
            {
                Console.WriteLine(ch1);
            }
