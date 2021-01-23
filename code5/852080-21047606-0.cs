            List<string>  n = new List<string>();
            n.AddRange( new string[] { "an folder ] ",
                "and ] another",
                "not this one",
                "[so] this is",
                "and [ a few more]",
                "OR num2 either",
                "lorem ipsum["});
            string pattern =@"(\[|\])"; // you don't need your \.* parts
            List<string> directoriesMatchingPattern = new List<string>();
            foreach (string d in n)
            {
                if (Regex.Match(d, pattern).Success)
                {
                    directoriesMatchingPattern.Add(d);
                }
            }
