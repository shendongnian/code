    var iEnum1 = exampleArray.Skip(1); // { "2", "3", "4", "5", "6", "7", "8", "9" }
    var iEnum2 = iEnum1.Take(5);       // { "2", "3", "4", "5", "6" }
    var iEnum3 = iEnum2.Skip(1);       // { "3", "4", "5", "6" }
    var iEnum4 = iEnum3.Take(2);       // { "3", "4" }
    int count = iEnum4.Count();        // 2
