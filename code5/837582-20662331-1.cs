public class Base
{
    public void Say()
    {
        Console.WriteLine("Base");
    }
}
public class Derived:Base
{
    public new void Say()
    {
        Console.WriteLine("Derived");
    }
}
public class SomeClient
{
    public void Run()
    {
        var d = new Derived();
        d.Say();
    }
}
