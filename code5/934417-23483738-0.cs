    class MyClass
    {
        // Static/Class constructor.
        // Note: Static constructors cannot have visibility modifier (eg. public/private),
        //       and cannot have any arguments.
        static MyClass()
        {
            ... // This will only execute once - when this class is first accessed.
        }
        // Normal/Instance Constructor.
        public MyClass(...)
        {
            ... // This will execute each time an object of this class is created.
        }
    }
