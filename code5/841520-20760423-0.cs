    public void Foo(ref int x) {}
    ...
    var method = typeof(Test).GetMethod("Foo");
    var parameter = method.GetParameters()[0];
    Console.WriteLine(parameter.ParameterType); // System.Int32&
    Console.WriteLine(parameter.ParameterType.GetElementType()); // System.Int32
