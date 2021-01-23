    public struct Bar
    {
       public Foo myFoo;
    }
    //
    var myBar = default(Bar); // this just can't return null since
                              // Bar is a value type
  
