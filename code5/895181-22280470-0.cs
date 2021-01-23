    string s = "Shipments will cost $150USD , which representes a rise of %34 .";
                var matches = Regex.Matches(s, @"(\$|%)\w+");
                for (int i = 0; i < matches.Count; i++)
                {
                    Console.WriteLine(matches[i].Value);
                }
