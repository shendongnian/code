    string newsql = "REPLACE INTO dan1 (first_name, last_name) values";
    newsql += "(";
    for (int i = 0; i < 2; i++)
    {
        newsql += reader.GetString(i);
    }
    newsql += ")";
    // System.Console.WriteLine(newsql);
