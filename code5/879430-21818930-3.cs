    // Here we use the SetEnumerable method without declaring a List<int>.
    // Therefore, if you later change underlying type to double, the code 
    // below can remain unchanged.
    var myEnumerable = new MyEnumerable();
    myEnumerable.SetEnumerable(1, 2, 3); 
