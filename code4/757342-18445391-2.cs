    public class MyClass
    {
      public List<string> MyList {get; private set;}
      public MyClass()
      {
         MyList = new []{"One","Two", "Three"}.ToList().AsReadOnly();
      }
    }
    public class Consumer
    {
      public void DoSomething()
      {
          MyClass myClass = new MyClass();
          myClass.MyList = new List<string>(); // This would not be allowed, 
                                               // due to the private setter
          myClass.MyList.Add("new string"); // This would not be allowed, because
                                            // the ReadOnlyCollection<string>
                                            // implementation will not allow the 
                                            // list to be modified
        }
    }
