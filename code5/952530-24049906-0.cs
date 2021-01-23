    class Foo
    {
        object Test()
        {
            return this.MemberwiseClone();  
            // Works, because Foo can see protected MemberwiseClone
            // inherited from Object
        }
    }
    class Bar
    {
        object Test()
        {
            var foo = new Foo();
            return foo.MemberwiseClone();
            // fails: Bar cannot see Foo's protected MemberwiseClone
            // because Bar does not inherit from Foo
        }
    }
