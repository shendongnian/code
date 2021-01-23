        List<char> InvalidCharacters = new List<char>() { 'a','b','c' };        
        static string StripInvalidCharactersFromField(string field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                string s = new string(new char[] { field[i] });
                if (InvalidCharacters.Contains(s))
                {
                    field = field.Remove(i, 1);
                    i--;
                }
            }
            return field;
        }
