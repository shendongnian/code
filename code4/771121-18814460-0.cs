        IEnumerable<string> Search(IEnumerable<string> data, string q)
        {
            string regexSearch = q
                .Replace("*", ".+")
                .Replace("%", ".+")
                .Replace("#", "\\d")
                .Replace("@", "[a-zA-Z]")
                .Replace("?", "\\w");
            Regex regex = new Regex(regexSearch);
            return data
                .Where(s => regex.IsMatch(s));
        }
