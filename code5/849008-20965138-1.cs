    DateTime.TryParseExact(
        string.Format("{0}/{1}/{2}", day, month, ddlYear.SelectedValue),
        "d/M/yyyy",
        null,
        System.Globalization.DateTimeStyles.None,
        out logDate);
