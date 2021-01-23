    class MyClass : IEditable
    { 
        internal int Age { get; private set; }
        int IEditable.Age { get; set; }
    }
