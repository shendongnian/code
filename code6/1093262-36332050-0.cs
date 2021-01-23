    MyClass myClass = new MyClass();
    PrivateType testObj = new PrivateType(myClass.GetType());
    DateTime fromDate = new DateTime(2015, 1, 1);
    DateTime toDate = new DateTime(2015, 3, 17);
    object[] args = new object[2] { fromDate, toDate };
    (int)testObj.InvokeStatic("GetMonthsDateDiff", args)
