    string num = db.SelectNums(id);
    string[] split = num.Split('-');
    
    int start = int.Parse(split[0]);
    int end = int.Parse(split[1]);
    
    List<string> results = new List<string>();
    
    for(int i = start; i <= end; i++)
    {
        results.Add(i.ToString());
    }
    
    string[] arrayResults = results.ToArray();
