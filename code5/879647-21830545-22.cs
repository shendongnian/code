    DangerousOperation
        .Try(() =>
        {
            throw new NotImplementedException();
        })
        .Catch((NotImplementedException exception) =>
        {
            Console.WriteLine(exception.Message);
        }).When(ex => !Debugger.IsAttached)
        .Catch((NotSupportedException exception) =>
        {
            Console.WriteLine("This block is ignored");
        }).When(ex => !Debugger.IsAttached)
        .Finally(() =>
        {
            Console.WriteLine("Goodbye");
        }).Execute();
