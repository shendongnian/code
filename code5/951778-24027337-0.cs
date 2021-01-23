    var dict = new Dictionary<MyClass, string>();
    var hashDict = new Dictionary<int, string>();
    dict[myObj1] = "One";
    hashDict[myObj1.GetHashCode()] = "One";
    dict[myObj2] = "Two";
    hashDict[myObj2.GetHashCode()] = "Two";
    Console.Out.WriteLine(dict[myObj1]);  //Outputs "One"
    Console.Out.WriteLine(hashDict[myObj1.GetHashCode()]); //Outputs "Two"
