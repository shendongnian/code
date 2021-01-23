    class Apple : IDisposable
    {
        HWND Core;
    
        ~Apple() { Free(); }
        Free()
        {
            if(Core != null)
            {
                CloseHandle(Core); 
                Core = null;
            }
        }
        Dispose() { Free(); }
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
