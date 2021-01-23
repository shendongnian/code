    public class MyClassd
    {
        public List<string> MyList {get; private set;}
    }
    public class Consumer
    {
      public void DoSomething()
      {
          MyClass myClass = new MyClass();
          myClass.MyList = new List<string>(); // This would not be allowed, 
                                               // due to the private setter
          myClass.MyList.Add("new string"); // This would be allowed, because it's
                                            // calling a method on the existing list--not replacing the list itself
        }
    }
