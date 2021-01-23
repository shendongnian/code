    string authorNames = string.Empty;
    for(int i = 0; i < book.Authors.Count(); i++)
    {
        if(i > 0)
            authorNames += ", ";
        authorNames += book.Authors[i].Name;
    }
