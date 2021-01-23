    public void DoSomething()
    {
        using (var connection = Connect())
        {
            DoSomething(connection);
        }
    }
    public void DoSomethingTwice()
    {
        using (var connection = Connect())
        {
            DoSomething(connection);
            DoSomething(connection);
        }
    }
    private void DoSomething(Connection connection)
    {
        connection.DoThatThing();
    }
