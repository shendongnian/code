    public MyClass2(MyClass1 other)
    {
        this.SomeProperty = other.SomeProperty;
        // etc
    }
    MyClass2 temp = new MyClass2((MyClass1)myObjectInput);
