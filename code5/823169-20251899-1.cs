    public void DoSomething()
    {
        UsingConnection(connection => DoSomething(connection));
    }
    public void DoSomethingTwice()
    {
        UsingConnection(
            connection => 
            {
                DoSomething(connection);
                DoSomething(connection);
            });
    }
    private void DoSomething(IDbConnection connection)
    {
        connection.DoThatThing();
    }
    private void UsingConnection(Action<IDbConnection> action)
    {
        using (var connection = Connect())
        {
            action(connection);
        }
    }
