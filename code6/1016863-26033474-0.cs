    public void TestFunction()
    {
        var test = new Test();
        System.Collections.Generic.HashSet<Test> hashSet = new System.Collections.Generic.HashSet<Test>();
        test.Code = "Change";
        hashSet.Add(test);
        hashSet.Remove(test);  //this doesn´t remove from the hashset
    }
