    class MyClass
    {
        public string Name;
        public int Age;
    }
    
    Type MyType = Type.GetType("MyClass");
    
    var MyObject = Activator.CreateInstance(MyType);    
