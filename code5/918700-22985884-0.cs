    var myDic = new Dictionary<string,string>();
    myDic.Add("1","One");
    myDic.Add("2","Two");
    myDic.Add("3","Three");
    myDic.Add("4","Four");
    //myDic.Dump();
    
    var exclusions = new []{"2","3"};
    var newDict = myDic.Where(x=> !exclusions.Contains(x.Key))
    	 .ToDictionary(x=> x.Key, x=> x.Value);
    //newDict.Dump();
