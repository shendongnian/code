    int number;
    bool result = Int32.TryParse(value, out number);
    if (result)
    {
        if (number > 1999 || number < 0)
        {
           MessageBox.Show("Value is invalid");
        }
        else
        {
           // action
        }
    }
    else
    {
       //Show that the input is not a numeric value
    }
