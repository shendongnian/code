    public void Foo(ref int x) { }
    ...
    var fooMethod = this.GetType().GetMethod("Foo");
    var param = fooMethod.GetParameters()[0];
    bool isByRef = param.ParameterType.IsByRef; // true
