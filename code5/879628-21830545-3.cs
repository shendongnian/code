    static void Main(string[] args)
    {
        using ( new DangerousOperation<Exception>()
        {
            Try = () =>
            {
                DoSomething();
            },
            Catch = exception =>
            {
                Console.WriteLine(exception.Message);
            }
        } ) { }
    }
