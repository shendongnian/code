    List<double> myList = new List<double>(1024);
    Console.WriteLine(myList.Capacity);
    myList.Add(1.0);
    myList.Add(2.0);
    Console.WriteLine(myList.Capacity);
    myList.Clear();
    Console.WriteLine(myList.Capacity);
