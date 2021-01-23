    public dynamic GetPersonOrObjectWhichHasExecutePersonMethod()
    {
     //return not the type but the object itself
     return new Person(); 
    }
    public class Person
    {
        public void executePersonMethod()
        {
          // do something
        }
    }
    // this is how you invoke it
    public void ExecuteMethod()
    {
      dynamic obj = GetPersonOrObjectWhichHasExecutePersonMethod();
      obj.executePersonMethod();
    }
