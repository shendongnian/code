    private bool IsValidData()
    {
        var errorMessages = new List<string>();
        if (!isPresent(txt_ArrivalDate, "Arrival Date"))
            errorMessages.Add("You must enter a value for this field.");
        if (!isPresent(txt_DepartDate, "Departure Date"))
            errorMessages.Add("Another message.");
        if (!isValidDate(txt_ArrivalDate, "Arrival Date"))
            errorMessages.Add("Another message.");
        ...
        if (errorMessages.Any())
            MessageBox.Show(string.Join(Environment.NewLine, errorMessages), "Errors");
        return !errorMessages.Any();  // returns false if errors found, otherwise true
    }
