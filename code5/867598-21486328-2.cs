    public class ClassBase
    {
      private string _name;
      public virtual string Name 
      { 
        get 
        { 
          CallMethod();
          return _name;
        }
        set
        {
          _name = value;
        }
      }
    }
    public class MyClass : ClassBase 
    {
      //Pretty pointless really since you're not doing anything with MyClass.Name.
      public new string Name
      {
        get
        {
          return base.Name;
        }
        set
        {
          base.Name = value;
        }
    }
    MyClass myClass = new MyClass();
    myClass.Name; <-- this will call the parent as well.
