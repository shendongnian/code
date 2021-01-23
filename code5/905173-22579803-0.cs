    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // do something if needed
        }
        
        // outside of postback, you need to add it each time
        Button button = new Button();
        button.ID = "btn1";
        button.Text = "clicky me";
        button.Click += new EventHandler(ButtonSubjectClick);
        pnl.Controls.Add(button);
    }
    void ButtonSubjectClick(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.Text = "clicked me";
    }
