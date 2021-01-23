    private bool _run = false;
    
    public void button_MouseDown(object sender, EventArgs e)
    {
        _run = true;
        MyAction();
    }
    public void button_MouseUp(object sender, EventArgs e)
    {
        _run = false;
    }
    public void MyAction()
    {
        while(_run)
        {
            //You actions
        }
    }
