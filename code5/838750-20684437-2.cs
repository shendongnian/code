    string result;
    var resultBuilder = new StringBuilder();
    foreach(string word in words)
    {
        // Get the first two characters if word has two characters
        if (word.Length >= 2)
        {
            resultBuilder.Append(word.Substring(0, 2));
        }
        else
        {
            // Append the whole word, because there are not two first characters to get
            resultBuilder.Append(word);
        }
    }
    result = resultBuilder.ToString();
