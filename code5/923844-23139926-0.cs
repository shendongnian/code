    List<int> ids = new List<int> { 1, 2, 3, 4, 5 }; //assuming your ids are like that
    List<object> objList = new List<object>();
    foreach (var item in ids)
    {
        objList.Add("p" + item);
        objList.Add(item);
    }
    object[] parms = objList.ToArray();
