    class A
    {
        public void Foo()
        {
            Log.PrintLog();
        }
    }
    
    public static class Log
    {
        public static void PrintLog([CallerMemberName] string function = null,
                                    [CallerFilePath] string path = null)
        {
            Console.WriteLine("Call from function {0}, file {1}", function, path);
        }
    }
