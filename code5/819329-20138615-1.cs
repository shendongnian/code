    for (int i = 0; i < d.Count; i++)
    {
        if (d.ElementAt(i).Key == word)
        {
            var val = d.ElementAt(i).Value + 1;
            d.RemoveAt(i);
            d.Add(word, val);
        }
    }
