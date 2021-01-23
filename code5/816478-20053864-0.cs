    protected void Page_Init(object sender, EventArgs e)
    {
        var button = new Button
        {
            ID = "helpButton_0",
            CommandArgument = "0",
            CssClass = "HelpButton",
            Text = "?"
        };
        button.Command += button_Command;
        PlaceHolder1.Controls.Add(button);
    }
    
    private void button_Command(object sender, CommandEventArgs e)
    {
        // Handle dynamic button's command event.
    }
