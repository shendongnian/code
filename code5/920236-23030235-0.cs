    var DataArray = System.IO.File.ReadAllLines(FilePath, Encoding.Default).Select(x => x.Split(';').ToArray()).ToArray();
    
    var ResultList = new List<Tuple<string, List<KeyValuePair<string, string>>>>();
    
    foreach (var Line in DataArray.Skip((1))) // Skip Header
    {
        String USER_EMPLOYEE_ID = Line[0];
        var KVpairs = new List<KeyValuePair<string, string>>();
    
    
        for (int i = 1; i < Line.Length; i += 2)
        {
            if (i + 1 < Line.Length)
                KVpairs.Add(new KeyValuePair<string, string>(Line[i], Line[i + 1]));
        }
    
        ResultList.Add(Tuple.Create(USER_EMPLOYEE_ID, KVpairs));
    }
