    int age;
    if (!int.TryParse(_Age.Text, out age))
    {
        // Error case - tell the user to enter a number
    }
    else
    {
        if (age < 65) 
        {
             _SeniorCitizen.Enabled = false;
        }
        else
        {
             _SeniorCitizen.Enabled = true;
        }
    }
