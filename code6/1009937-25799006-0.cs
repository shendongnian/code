    public class MyClass
    {
         private string connString;
         // exec stored procedure 1
    }
    public class MySubClass : MyClass
    {
          otherClass o = new otherClass(connString);
          // exec stored procedure 2
    }
