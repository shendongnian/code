    private void ValidateText(object sender, EventArgs e)
    {
        TextBox txtBox = sender as TextBox;
        String strpattern = @"^-?\d*\.?\d*"; //Pattern is Ok
        Regex regex = new Regex(strpattern);
        if (!regex.Match(txtBox.Text).Success)
        {
            // passed
        }
    }
