    private void AddRow(Panel pnl, int index)
    {
        var myButton = new Button();
        myButton.ID = "button_" + index; // add this line (the index will guarantee a distinct ID)
        myButton.Text = "+";
        myButton.Attributes.Add("onclick", "return MyJavascript();");
        myButton.Attributes.Add("somevariable", "FOOBAR!");
        var lblAnzahl = new Label();
        pnl.Controls.Add(myButton);
        pnl.Controls.Add(lblAnzahl);
    }
