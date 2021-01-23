    internal interface IKeyable
    {
      int ID {get; set;}
    }
    internal class MyClass: IKeyable
    {
      public int ID  { get; set; }
    }
