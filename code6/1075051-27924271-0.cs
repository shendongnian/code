    if(isValid)
    {
        // Valid so do something with the date value.
        model.MyDate = dt.Value;
    }
    else
    {
        // Invalid so show an error message to the user.
        MessageBox.Show("Date format is invalid", "Invalid Date", MessageBoxButtons.OK);
    }
