    void Method()
    {
        var intermediates = new Intermediate[100];
        Parallel.For(0, 100, i =>
        {
            // ...
            intermediates[i] = ...;
        });
    
        Parallel.For(0, 100, i =>
        {
            var intermediate = intermediates[i];
            // ... use intermediate
        });
    }
