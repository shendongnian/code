    public void CreateDynamicButtons()
    {
        Button b1 = new Button();
        b1.Click += new EventHandler(OnClick);
 
        // Or you could simply do
        Button b2 = new Button();
        b2.Click += OnClick;
    }
    protected void OnClick(Object sender, EventArgs e)
    {
        // This is called when b1 or b2 are clicked
    }
