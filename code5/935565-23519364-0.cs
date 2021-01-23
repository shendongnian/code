    public  DayOfWeek FirstDayOfWeek
    { 
        get
        {
             // FirstDayOfWeek is always set in the Calendar setter.
             return ((DayOfWeek)firstDayOfWeek); 
        }
     
        set { 
              VerifyWritable();
              if (value >= DayOfWeek.Sunday && value <= DayOfWeek.Saturday) { 
              firstDayOfWeek = (int)value;
            } else {
                    throw new ArgumentOutOfRangeException(
                            "value", String.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("ArgumentOutOfRange_Range"), 
                            DayOfWeek.Sunday, DayOfWeek.Saturday));
              } 
         } 
    }
