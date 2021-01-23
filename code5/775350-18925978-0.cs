            string[] inputstrings = new string[] { "Total Hours Worked (.5);", "Total Hours Worked (.A);", "Total Hours Worked (A);" };//Collection of inputs.
            Regex rgx = new Regex(@"\(\.?(?<StringValue>[a-zA-Z]*)\)\;{1}");//Regular expression to find all matches.
            foreach (string input in inputstrings)//Iterate through each string in collection.
            {
                Match match = rgx.Match(input);
                if (match.Success)//If a match is found.
                {
                    string value = match.Groups[1].Value;//Capture first named group.
                    Console.WriteLine(value);//Display captured substring.
                }
                else//If nothing is found.
                {
                    Console.WriteLine("A match was not found.");
                }
            }
