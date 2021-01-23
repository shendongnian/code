    class Foo
    {
        public int Baz { get; set; }
    }
   
    MyClass<Foo>.TypeHasProperty(f => f.Baz);
