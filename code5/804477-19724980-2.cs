    var ints1 = new List<int>();
    var ints2 = new List<int>();
    ints1.Add(1);
    ints2.Add(1); // Change this to .Add(2) and the unit test fails.
    var objList1 = new List<object> { ints1 };
    var objList2 = new List<object> { ints2 };
    var x = new List<object> { objList1 };
    var y = new List<object> { objList2 };
    x.ShouldBeEquivalentTo(y, "Expected response not the same as actual response.");
