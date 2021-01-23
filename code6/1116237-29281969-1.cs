    public class B : A
    {
      string Stuff{get;set}
      public B(string stuff)
      {
        Stuff = stuff;
      }
      public B() : base()  // technically the ": base()" is redundant since A only has one constructor
      {
      }
    }
