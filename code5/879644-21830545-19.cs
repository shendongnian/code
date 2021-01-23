    static void Main(string[] args)
    {
        new DangerousOperation()
            .Try(() =>
            {
                throw new NotImplementedException();
            })
            .Catch((NotImplementedException exception) =>
            {
                Console.WriteLine(exception.Message);
            }, false)
            .Catch((NotSupportedException exception) =>
            {
                Console.WriteLine("This block is ignored");
            })
            .Finally(() =>
            {
                Console.WriteLine("Goodbye");
            });
    }
