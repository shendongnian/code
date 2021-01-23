    public void Foo() {
        var foo = 1;
        if(true) {
            foo = 2;
            Console.WriteLine("inside block: " + foo);  // prints 2
        }
        Console.WriteLine("outside block: " + foo);     // prints 2
    }
