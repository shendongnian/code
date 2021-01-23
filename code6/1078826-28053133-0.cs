    private void carga_todos(object sender, KeyPressEventArgs e)
    { 
        if (e.KeyChar == (char)Keys.Enter)
        {
           DoSomething();
        }
    }
    private void AnotherFunctionThatNeedsToDoSomethingToo()
    {
        DoSomething();
    }
    private void DoSomething()
    {
        // stuff to do
    }
