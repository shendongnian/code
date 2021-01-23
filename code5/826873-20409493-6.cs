    var foo = new Bar();
    using (foo)
    {
        ...  // This is the code block
    }
    
    foo.DoSomething();   // <- Outside the block, this will compile
