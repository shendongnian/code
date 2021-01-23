    public class CSharpDerived : Foo
    {
      public override void Bar()
      {
        System.Console.WriteLine("In director method");
        throw new System.Exception("This is a special message");
      }
    }
