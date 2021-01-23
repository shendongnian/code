        internal IDbCommand SetupCommand(IDbConnection cnn, Action<IDbCommand, object> paramReader)
        {
            var cmd = cnn.CreateCommand();
    #if ASYNC
            // We will cancel our IDbCommand
            CancellationToken.Register(() => cmd.Cancel());
    #endif
