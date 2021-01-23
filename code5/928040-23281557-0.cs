            public static string RemoveMultiSpace(string input)
        {
            if (string.IsNullOrEmpty(input)) { return "Wrong input"; }
            input = input.TrimEnd().TrimStart();
            StringBuilder result = new StringBuilder();
            for (int x = 0; x < input.Length; x++)
            {
                // add letter if not space or tab
                if (input[x] != ' ' && input[x] != '\t')
                {
                    result.Append(input[x]);
                }
                else
                {
                    char char2Append = input[x];
                    char lastLetter = input[x - 1];
                    char firstLetter = '\0';
                    //find first letter of the next word
                    while (input[x + 1] == ' ' || input[x + 1] == '\t')
                    {
                        x++;
                    }
                    firstLetter = input[x + 1];
                    if (lastLetter >= 97 && lastLetter <= 122 && firstLetter >= 65 && firstLetter <= 90)
                    {
                        result.Append(char2Append);
                    }
                }
            }
            return result.ToString();
        }
