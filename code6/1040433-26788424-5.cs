    public class Parent { public string Name { get; set; } }
    public class Child : Parent { public Parent Parent { get; set; } }
    public static void Introduce(Parent p)
    {
        Console.WriteLine("Hello, my name is: {0}", p.Name);
        if (p is Child)
        {
            Child c = p as Child;
            Console.WriteLine(" - and my parent's name is: {0}", c.Parent.Name);
        }
    }
    private static void GenericTester()
    {
        Parent p = new Parent {Name = "Dad"};
        Child c = new Child {Name = "Son", Parent = p};
        Introduce(p);
        Introduce(c);
    }
    // Ouput:
    // Hello, my name is: Dad
    // Hello, my name is: Son
    //  - and my parent's name is: Dad
