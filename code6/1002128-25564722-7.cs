    using (StatementReader statementReader = new CodeFluent.Runtime.Database.Management.StatementReader("GO", Environment.NewLine, inputStream))
    {
        Statement statement;
        while ((statement = statementReader.Read(StatementReaderOptions.Default)) != null)
        {
            Console.WriteLine("-- ");
            Console.WriteLine(statement.Command);
        }
    }
