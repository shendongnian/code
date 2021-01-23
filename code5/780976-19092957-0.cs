        string[] extractBetweenQuotes(string str)
        {
            var list = new List<string>();
            int firstQuote = 0;
            firstQuote = str.IndexOf("\"");
            while (firstQuote > -1)
            {
                int secondQuote = str.IndexOf("\"", firstQuote + 1);
                if (secondQuote > -1)
                {
                    list.Add(str.Substring(firstQuote + 1, secondQuote - (firstQuote + 1)));
                    firstQuote = str.IndexOf("\"", secondQuote + 1);
                    continue;
                }
                firstQuote = str.IndexOf("\"", firstQuote + 1);
            }
            return list.ToArray();
        }
