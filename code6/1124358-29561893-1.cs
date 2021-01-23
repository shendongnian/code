    var exampleList = new List<string>{"1", "2", "rubbish", "3", "trash", "4.5"};
    int dummyInt; // just because you need an out param of type int
    // filteredInts will contain {1, 2, 3}
    var filteredInts = exampleList.Where(item => int.TryParse(item, out dummyInt));
    double dummyDouble; // just because you need an out param of type double
    // filteredDoubles will contain {1, 2, 3, 4.5}
    var filterdDoubles = exampleList.Where(item => double.TryParse(item, out dummyDouble));
