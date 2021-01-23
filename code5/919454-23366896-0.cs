    static void Main()
    {
        Application.CurrentCulture = new System.Globalization.CultureInfo("nl-BE");
        var keys = Keys.Shift | Keys.N;
        var keysstring = new KeysConverter().ConvertToString(keys);
    } 
