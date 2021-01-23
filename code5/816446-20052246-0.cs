    //old calling code
    Base.a = 7; // does not create an instance
    Console.WriteLine(Base.a);
    class MyClass :Base
    {
       public static string a {get; set;}
    }
    //new calling code
    MyClass.a = "some string"; // uses whatever a you defined in MyClass
    Console.WriteLine(MyClass.a);
