    // Write
    List<string> _listA = new List<string>(4);
    _listA.Add("Test");
    _listA.Add("Test2");
    _listA.Add("Test3");
    _listA.Add("Test4");
    System.IO.File.WriteAllLines("test.txt", _listA);
    // Read
    List<string> _listB = new List<string>(4);
    _listB.AddRange(System.IO.File.ReadAllLines("test.txt"));
