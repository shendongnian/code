    string valueToPutInDatabase;
    if(string.IsNullOrEmpty(yourTextBox.Text))
    {
     //Your textbox was empty
     valueToPutInDatabase = null;
    }
    else
    {
     valueToPutInDatabase = yourTextBox.Text;
    }
