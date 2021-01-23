    public class MyClass
    {
      public IList<string> MyList {get; private set;}
      public MyClass()
      {
         MyList = new List<string>(){"One","Two", "Three"}.AsReadOnly();
      }
    }
    public class Consumer
    {
      public void DoSomething()
      {
          MyClass myClass = new MyClass();
          myClass.MyList = new List<string>(); // This would not be allowed, 
                                               // due to the private setter
          myClass.MyList.Add("new string"); // This would not be allowed, the
                                            // ReadOnlyCollection<string> would throw
                                            // a NotSupportedException
        }
    }
