      string s1 = "Have a good day";
            string s2 = "Have a very good day, Joe";
            int index = s2.IndexOf(','); <----- get the index of the char to be removed
            IEnumerable<string> diff;
            IEnumerable<string> first = s1.Split(' ').Distinct();
            IEnumerable<string> second = s2.Remove(index, 1).Split(' ').Distinct();<--- remove it
            if (second.Count() > first.Count())
            {
                diff = second.Except(first).ToList();
            }
            else
            {
                diff = first.Except(second).ToList();
            }
