    protected void Page_Load(object sender, EventArgs e)
    {
        // attach event handlers
        Button1.Click += ButtonClick;
        Button2.Click += ButtonClick;
        Button3.Click += ButtonClick;
        Button4.Click += ButtonClick;
    }
 
    private void ButtonClick(object sender, EventArgs e)
    {
        // your code here...
        // this is the button that raised the event
        Button button = (Button)sender;    
        // check its ID? you could also check its text, perform any actions you wish, etc.    
        if (button.ID == "Button1")
        {
            System.Diagnostics.Debug.Print("Button 1 Clicked!");
        }
    }
