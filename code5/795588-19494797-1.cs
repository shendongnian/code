    class MyClass
    {
       public MyClass(MyClass arg)
       {
          this.CopyFrom(arg);
       }
       void CopyFrom(MyClass m)
       {
          // Assign fields from m.
       }
    }
