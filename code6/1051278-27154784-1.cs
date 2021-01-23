    protected void Page_Load(object sender, EventArgs e)
    {
        Button1.Click += Button1_Click;
    
        if (!SomeCheck())
        { 
            // Only fire Button2 Click if SomeCheck Fails
            Button2.Click += Button2_Click;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
    }
