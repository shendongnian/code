    string value;
    foreach (string words in split)
    {
        if (device.TryGetValue(words, out value))
        {
            return value;
        }
    }
