    int a = 4;
    if (a > 3)
    {
        SetLabelToHello();
    }
    else
    {
        SetLabelToHi();
    }
    // ....
    public void SetLabelToHello()
    {
        Label1.Text = "Hello";
        Label2.Text = "How are you?";
    }
    public void SetLabelToHi()
    {
        Label1.Text = "Hi";
        Label2.Text = "How do you do";
    }
