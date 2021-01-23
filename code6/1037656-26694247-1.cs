    protected void ValidateDate(Object sender, ServerValidateEventArgs e)
    { 
        string[] allowedFormats = { "dd/MM/yyyy","dd-MM-yyyy", "dd-MM-yyyy" };
        DateTime dt;
        e.IsValid = DateTime.TryParseExact(e.Value, allowedFormats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt);
    }
