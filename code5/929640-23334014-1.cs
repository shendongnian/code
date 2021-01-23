    public static void Main(string[] args)
    {
        while(!Debugger.IsAttached)
        {
            Thread.Sleep(1000); //Sleep 1 second and then check again.
        }
        //Rest of your code here
    }
