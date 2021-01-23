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
        .Catch<InvalidProgramException>() /* specifying a handler is optional */
        .Catch()                          /* In fact, specifying the exception type is also optional */
        .Finally(() =>
        {
            Console.WriteLine("Goodbye");
        }).Execute();
