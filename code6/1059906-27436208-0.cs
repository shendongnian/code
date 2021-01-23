    // create
    var listArray = new List<string[]>():
    string whatIWantToFind;
    // fill your array here...
    // search
    foreach(string[] listItem in listArray)
    {
        foreach(string item in listItem)
        {
             // you can compare
             if(item == whatIWantToFind)
             {
             }
             // or check if it contains
             if(item.Contains(whatIWantToFind))
             {
             }
        }
    }
