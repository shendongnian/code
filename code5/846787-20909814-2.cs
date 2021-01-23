    for (int i = 0; i < glossarywords.Items.Count; i++)
    {
        // get the item as string
        string itemValue = glossarywords.Items[i].ToString();
        // split the string by empty space which will separate all words
        string[] itemWords = itemValue.ToString().Split(' ');
        // check if any of the words within the current value is within the stopwords list
        if (itemWords.Any(word => stopWords.Contains(word)))
        {
            glossarywords.Items.RemoveAt(i);
        }
    }
