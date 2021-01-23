    // create
    var listArray = new List<string[]>():
    string whatIWantToFind = "1234";
    string[] mySearchArray = new string[] {"1234", "234234", "324234"};
    // fill your array here...
    // search
    foreach(string[] listItem in listArray)
    {
        // if you want to check a single item inside...
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
        // to compare everything..
        bool checked = true;
        for(int i = 0; i < listItem.lenght; i++)
        {
           if(!listItem[i].Equals(mySearchArray[i])
           {
               checked = false; break;
           }
        }
        // aha! this is the one
        if(checked) {}
    }
