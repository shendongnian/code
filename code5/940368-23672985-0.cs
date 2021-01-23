    private string ParseUrlInText(string text)
    {
        string currentText = text;
        var workingText = currentText.Split(new[] { "\r\n", "\n", " ", "</br>" }, 
                              StringSplitOptions.RemoveEmptyEntries).Distinct() // .Distinct() gives us just unique entries!
        foreach (string word in workingText)
        {
            string thing;
            if (word.ToLower().StartsWith("www."))
            {
                if (IsAllUpper(word))
                {
                    thing = "HTTP://" + word;
                    currentText = currentText.Replace("\r\n" + word, "\r\n" + thing)
                                             .Replace("\n" + word, "\n" + thing)
                                             .Replace(" " + word, " " + thing)
                                             .Replace("</br>" + word, "</br>" + thing)
                }
            }
        }
        return currentText;
    }
