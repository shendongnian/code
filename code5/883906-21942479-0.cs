    private string DoSomething()
    {
        ...
        ...
        return "someValue";
    }
    private void Button1_Click(object sender, EventArgs e)
    {
        DoSomething();  // execute the code
    }
    private void Button1_MouseEnter(object sender, EventArgs e)
    {
        DoSomething();  // execute the code here too
    }
    private void SomeOtherMethodThatNeedsTheReturnValue()
    {
        var returnValue = DoSomething();  // execute the code, use the return value
        // do something else with the returnValue
    }
