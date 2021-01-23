    class MyClass{
       String nonstaticField;
       static String staticField;
       static Foo(String obj){
          nonstaticField.Trim(); // no
          staticField.Trim()     // yes
          obj.Trim();            // yes
        }
    }
