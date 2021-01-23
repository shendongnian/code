    string searchString = "Hmmm_Joke.pdf";
    ArrayList newList = new ArrayList();
    foreach(string item in list)
    {
        if(!item.ToLower().Contains(searchString.ToLower()))
        {
            newList.Add(item);
        }
    }
