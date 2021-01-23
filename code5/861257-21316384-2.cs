    class Z : Y
    {
        // Attempting to override F causes compiler error CS0239. 
        // protected override void F() { Console.WriteLine("C.F"); }
        // Overriding F2 is allowed. 
        protected override void F2() { Console.WriteLine("Z.F2"); }
    }
