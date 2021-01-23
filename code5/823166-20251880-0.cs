    public void DoSomething(Connect connection)
    {
        connection.DoThatThing();
    }
    public void DoSomethingTwice()
    {
        using (var connection = new Connect())
        {
            DoSomething(connection);
            DoSomething(connection);
        }
    }
