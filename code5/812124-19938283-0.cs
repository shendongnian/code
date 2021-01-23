    public class Parser
    {
        bool inQuotes;
        public Parser()
        {
            inQuotes = false;
        }
        public List<string> Parse(string input)
        {
            List<string> output = new List<string>();
            StringBuilder temporaryString = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\'' && !inQuotes)
                {
                    inQuotes = true;
                    continue;
                }
                else if (input[i] == '\'' && inQuotes)
                {
                    output.Add(temporaryString.ToString());
                    inQuotes = false;
                    temporaryString = new StringBuilder();
                }
                else if (inQuotes)
                {
                    temporaryString.Append(input[i]);
                }
            }
            return output;
        }
    }
