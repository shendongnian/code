    MyClass myClass = new MyClass();
    PrivateObject testObj = new PrivateObject(myClass);
    DateTime fromDate = new DateTime(2015, 1, 1);
    DateTime toDate = new DateTime(2015, 3, 17);
    object[] args = new object[2] { fromDate, toDate };
    
    //The extra flags
     BindingFlags flags = BindingFlags.Static| BindingFlags.NonPublic
    int res = (int)testObj.Invoke("GetMonthsDateDiff",flags, args); 
