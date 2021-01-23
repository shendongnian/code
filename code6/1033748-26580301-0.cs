    // words dictionary has a word key and a list of lines containing the word
    var words = new Dictionary<string, List<string>>();
    using (var strReader = new StreamReader(@"pathToFile/Text.txt"))
    {
        string line;
        // Read each line
        while ((line = strReader.ReadLine()) != null)
        {
            // Get each word from the line
            var wordsInLine = line.ToLower().Split(' ');
            foreach (var word in wordsInLine)
            {
                // If this word already exists, update it's line number
                if (words.ContainsKey(word))
                {
                    words[word].Add(line);
                }
                    // Otherwise, add a new word with this line number to the list
                else
                {
                    words.Add(word, new List<string> {line});
                }
            }
        }
    }
