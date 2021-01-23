    static void Main()
    {
        var a = "10111010000";
        var b = "10111010011";
        var c = "10111101111";
       var aList = Split(a, 4); //Use a custom split method
       var bList = Split(b, 4);
       var cList = Split(c, 4);
       Dictionary<int,string> hits = new Dictionary<int, string>();
       for (int i = 0; i < aList.Count(); i++)
       {
           if(aList[i] == bList[i] && bList[i] == cList[i])
               hits.Add(i,aList[i]);
       }
    }
