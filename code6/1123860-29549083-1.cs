    DateTime finalValue;            
    try
    {
        TimeSpan ddValue = TimeSpan.Parse(dropdownValue);
        finalValue = pickerValue.Date.AddTicks(ddValue.Ticks);
    }
    catch (Exception)
    {
        //handle exception
        // most likely dropdownValue is not properly formatted timeString.
        finalValue = pickerValue.Date; //or however you would like to handle
    }
