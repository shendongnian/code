    string searchString = "Hmmm_Joke.pdf";
    foreach (string item in list.ToArray())
    {
        if (item.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
        {
            list.Remove(item);
        }
    }
