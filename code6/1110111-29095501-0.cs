    DateTime dt;
    if(DateTime.TryParseExact("16/05", "dd/MM", CultureInfo.InvariantCulture,
    						  DateTimeStyles.None, out dt))
    {
         if(DateTime.Today > dt)
         {
              // Your operation
         }
    }
