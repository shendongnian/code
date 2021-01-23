        private static string GetLetters(string s)
        {
            string newString = "";
            foreach (var item in s)
            {
                if (char.IsLetter(item))
                {
                    newString += item;
                }
            }
            return newString;
        }
