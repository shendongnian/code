    var arrayOfList = new List<int>[10];
    for (var i = 0; i < 10; i++)
    {
        // initialize each entry of the array
        arrayOfList[i] = new List<int>();
    }
    
    // add some stuff to entry one at a time
    arrayOfList[0].Add(1);
    // add some integers as a range
    arrayOfList[0].AddRange(new [] {2, 3, 4});
    
    // add some stuff to entry 1
    arrayOfList[1].AddRange(new [] {5, 6});
    
