    string[] testArray = new string[5] {"Test1", "Test2", "Test3", "Test4", "Test5"};
    var nameDict = new Dictionary<string, string>();
    for (int index = 0; index < testArray.Length; index++)
    {
        nameDict.Add(testArray[index], "some string value");
    }
