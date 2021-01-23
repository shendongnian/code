    DateTime finalValue = null;            
    try
    {
        TimeSpan ddValue = TimeSpan.Parse(dropdownValue);
        finalValue = pickerValue.Date.AddTicks(ddValue.Ticks);
    }
    catch (Exception)
    {
       //handle exception
    }
