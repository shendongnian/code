    public void DoSomething(Connection connection)
    {
        connection.DoThatThing();
    }
    public void DoSomethingTwice()
    {
        using (var connection = Connect())
        {
            DoSomething(connection);
            DoSomething(connection);
        }
    }
