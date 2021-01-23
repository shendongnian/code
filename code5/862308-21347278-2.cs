    using System.Globalization;
    DateTime dt;
    if (DateTime.TryParseExact(txtDate.Text,"dd-MM-yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None,out dt))
    {
      string s= dt.ToString("dd-MMM-yyyy");
    }
    else
    {
     //error message invalid date
    }
