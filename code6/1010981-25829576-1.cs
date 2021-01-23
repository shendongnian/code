    class MyExtClass : MyClass {
         public string MyNewField;
    }
    ...
    MyClass myObj = new MyExtClass();
    myObj.MyField = "OK";
    myObj.MyNewField = "FAIL"; // compiler will complain at this line
                               // because MyClass does not have it
