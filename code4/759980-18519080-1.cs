    public void Foo()
    {
        this.BeginInvoke(new Action(Bar)); //BeginInvoke will call the function Bar()
    }
    
    private void Bar()
    {
    }
