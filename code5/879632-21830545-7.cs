    new DangerousOperation()
        .Try(action: () =>
        {
            throw new NotImplementedException();
        },
        Catch: (NotImplementedException exception) =>
        {
            Console.WriteLine(exception.Message);
        },
        Finally: () =>
        {
            Console.WriteLine("Goodbye");
        });
