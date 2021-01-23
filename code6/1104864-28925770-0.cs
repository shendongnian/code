    string s = textBoxTradeDate.Text;
    DateTime dt;
    if(DateTime.TryParseExact(s, "yyyy-MM-dd",
                              CultureInfo.InvariantCulture,
                              DateTimeStyles.None, out dt))
    {
        // You have a valid datetime.
    }
