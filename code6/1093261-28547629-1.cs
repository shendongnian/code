    var myClass = new MyClass();
    var fromDate = new DateTime(2015, 1, 1);
    var toDate = new DateTime(2015, 3, 17);
    var args = new object[2] { fromDate, toDate };
	var type = myClass.GetType();
    // Because the method is `static` you use BindingFlags.Static 
    // otherwise, you would use BindingFlags.Instance 
    var getMonthsDateDiffMethod = type.GetMethod(
        "GetMonthsDateDiff",
        BindingFlags.Static | BindingFlags.NonPublic);
    var res = (int)getMonthsDateDiffMethod.Invoke(myClass, args);
