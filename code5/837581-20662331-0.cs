public class Base
{
  // there is no Say method in Base!
}
public class Derived:Base
{
    public /*new*/ void Say() // we don't need new here
    {
        Console.WriteLine("Derived");
    }
}
