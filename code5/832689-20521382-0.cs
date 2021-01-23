    IDictionary<string, IList<TYPE>> myContainer = new Dictionary<string, List<TYPE>>();
    myContainer.Add("key1", new List<TYPE>());
    myContainer["key1"].Add("SomeTYPE-1");
    myContainer["key1"].Add("SomeTYPE-2");
    myContainer["key1"].Add("SomeTYPE-3");
    myContainer.Add("key2", new List<TYPE>());
    myContainer["key2"].Add("A");
    myContainer["key2"].Add("B");
    myContainer["key2"].Add("C");
