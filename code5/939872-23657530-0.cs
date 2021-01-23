    using System.Linq;
    foreach(Class2 c in Class1.Class1Objects.OfType<Class2>())
    {
        Console.WriteLine(c.name); // or whatever you need to do with it
    }
