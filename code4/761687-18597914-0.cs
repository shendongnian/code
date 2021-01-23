    class Apple : IDisposable
    {
        HWND Core;
    
        ~Apple()
        { 
            if(Core != null)
            {
                Cleanup(Core); 
                Core = null;
            }
        }
        Cleanup()
        {
            if(Core != null)
            {
                Cleanup(Core); 
                Core = null;
            }
        }
        Dispose() { Cleanup(); }
    }
    class Tree : IDisposable
    {
        List<Apple> Apples;
        Dispose()
        {
            foreach(var apple in Apples)
                apple.Dispose();
        }
    }
