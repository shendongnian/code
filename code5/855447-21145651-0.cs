    int length = 4;
    var lists = new List<List<string>>();
    var random = new Random(1234);
    
    for(int i = 0; i < length; i++)
    {        
        var inLength = random.Next(4, 8);
        var tempList = new List<string();
        for (int j = 0; j < inLength; j++_
        {
            tempList.Add(string.Format("{{String Coords: {0}, {1}}}", i, j));
        }
        lists.Add(tempList);
    }
    
    var cp= lists.CartesianProduct();
    var output = RenderString(cp);
