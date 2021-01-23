            List<string> everything = new List<string> { "20131105", "1", "A", "11/05/2013 22:43", "2.3", "21/11", "null", "2012" };
            List<string> allDates = new List<string>();
            DateTime d;
            foreach (string s in everything)
            {
                if (s.Length < 10) continue;
                if (DateTime.TryParse(s, out d))
                {
                    allDates.Add(s);
                }
            }
