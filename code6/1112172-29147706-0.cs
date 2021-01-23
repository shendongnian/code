    string MyString = "whatever";
    List<int> indexes = new List();
    for (int i = 0; i < location.Count; i++)
    {
        if (location[i] == MyString)
        {
           indexes.Add(i);
        }
    }
