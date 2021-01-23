    protected void Page_Load(object sender, EventArgs e)
    {
            CreateControls();
            UpdatePage();
    }
    
    protected void CreateControls()
    {
        Button button1 = new Button();
        button1.ID = "_Button1";
        button1.Text = "Button1";
        button1.Click += new System.EventHandler(_ClickEvent);
        _Panel.Controls.Add(button1);
    
        Button button2 = new Button();
        button2.ID = "_Button2";
        button2.Text = "Button2";
        button2.Click += new System.EventHandler(_ClickEvent);
        _Panel.Controls.Add(button2);
    }
    
    protected void UpdatePage()
    {
        Button button1 = ((Button)_Panel.FindControl("_Button1"));
        button1.Text = "I went through UpdatePage and changed";
    
        Button button2 = ((Button)_Panel.FindControl("_Button2"));
        button1.Text = "I went through UpdatePage and changed";
    }
    
    protected void _ClickEvent(object sender, EventArgs e)
    {
    
    }
