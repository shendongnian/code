    public void f()
    {
        Dts.Variables["MyObjectVar"].Value = "Hello";
    }
    //inside another script task
    public void g()
    {
        object myObjectVar = Dts.Variables["MyObjectVar"].Value;
        string myString = (string)myObjectVar;
        //myString will contain "Hello" if f() is executed before g()
    }
