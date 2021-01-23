    string[] lines = new string[] {"1","2","3","4","5","6","7","8","9"};
    List<string> copyList = lines.ToList();
    for(int x = copyList.Count()- 1; x > 0; x--)
    {
        if(x % 2 == 0)
            copyList.Insert(x, "");
    }
    
    string combinedString = string.Join(Environment.NewLine, copyList);
