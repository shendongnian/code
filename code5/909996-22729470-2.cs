    List<int> ints = new List<int>();
    List<MyInt> myInts = new List<MyInt>();
    // assign 1 to 5 in both collections
    for(int i = 1; i <= 5; i++) {
        ints.Add(i);
        myInts.Add(new MyInt(i));
    }
