    void SomeFunction()
    {
        int variable;
        Execute((a) => variable = a);
    }
    void Execute(Action<int> statement)
    {
        statement.Invoke(7);
    }
