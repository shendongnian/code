    public void inputTextBox_Clicked(object sender, EventArgs e)
    {
        var input = (sender as TextBox).Text;
        if( Tools.IsNumeric(input) )
        {
            ...
        }
    }
