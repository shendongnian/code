    string searchString = "Hmmm_Joke.pdf";
    foreach(string item in list)
    {
        if(item.Contains(searchString))
        {
            list.Remove(item);
        }
    }
