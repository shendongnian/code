        public string ReplaceWhitespaceWithChar(string input,char ch)
        {
            string temp = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    temp += input[i];
                }
                else if (input[i] == ' ' && input[i + 1] != ' ')
                {
                    temp += ch;
                }
            }
            return temp;
        }        
