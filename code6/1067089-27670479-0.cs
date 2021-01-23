    DateTime date;
    if (DateTime.TryParse(string.Format("{0}-{1}-{2}", year, month, day), out date))
    {
        // Date was valid.
        // date variable now contains a value.
    }
    else
    {
        // Date is not valid, default to today.
        date = DateTime.Today;
    }
