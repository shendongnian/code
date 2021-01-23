    public string DateCheck()
    {
        var startOfWeek = StartOfWeek(_today);
        var endOfWeek = startOfWeek.AddDays(7);
        return string.Format("Current Rent Week: {0} - {1}",
            startOfWeek.ToString("dd/MM/yyyy"),
            endOfWeek.ToString("dd/MM/yyyy"));
    }
