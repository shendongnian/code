    DateTime dt;
    if (DateTime.TryParseExact("201010", "yyyyMM",
                                CultureInfo.InvariantCulture,
                                DateTimeStyles.None, out dt))
    {
      if (dt < DateTime.Now.Date)
      {
        MessageBox.Show(@"period cover must be higher than year and month now");
      }
    }
