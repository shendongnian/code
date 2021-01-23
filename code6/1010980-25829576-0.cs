    class MyClass {
         public string MyField;
    }
    ...
    var myObj = new MyClass();
    myObj.MyField = "OK";
    myObj.NotMyField = "FAIL"; // compiler will complain at this line
