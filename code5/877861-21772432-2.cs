    public void Foo(){
        if(true){
            var foo = 1;
            Console.WriteLine("inside block: " + foo);
        }
        Console.WriteLine("outside block: " + foo);  // WILL NOT COMPILE
    }
