    public class Foo: ProtoObject {}
    public class Bar: Foo {}
    
    dynamic myFoo = new Foo();
    dynamic yourFoo = new Foo();
    dynamic myBar = new Bar();
    
    myFoo.Prototype.Name = "Josh";
    myFoo.Prototype.SayHello = new Action(s => Console.WriteLine("Hello, " + s));
    
    yourFoo.SayHello(myBar.Name); // 'Hello, Josh'
