    private static void GetSuggestionOption(string filename, string value, string optionSuggest)
            {
                XDocument xDoc = XDocument.Parse(filename);
                var parentNode = xDoc.Descendants().Where(x => x.Value == value).Ancestors().FirstOrDefault();
                var childNode = parentNode.Descendants().Where(x => x.Name == optionSuggest);
                childNode.ToList().ForEach(x => Console.WriteLine(x.Value));
            }
