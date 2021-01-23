    string NumberLength = TextBoxPhoneNumber.Text;
    int Number;
    if (int.TryParse(NumberLength, out Number))
    {
        //I parsed the number out. Now lets get the length
        NumberLength = Number.ToString(CultureInfo.InvariantCulture);
    
        if (NumberLength.Length > 10)
        {
            LblInfo.Visible = true;
            LblInfo.ForeColor = Color.Red;
            LblInfo.Text = "Phone number can not be longer than 10 digits!";
            boolIsValid = false;
        }
        else if (NumberLength.Length < 10)
        {
            LblInfo.Visible = true;
            LblInfo.ForeColor = Color.Red;
            LblInfo.Text = "Phone number can not be shorter than 10 digits!";
            boolIsValid = false;
        }
        else
        {
            LblInfo.Visible = false;
            boolIsValid = true;
        }
    }
    else
    {
        LblInfo.Visible = true;
        LblInfo.ForeColor = Color.Red;
        LblInfo.Text = "Phone number can only contain digits!";
        boolIsValid = false;
    }
