    String strMonth =drpMonth.SelectedItem.Value;
    String strDay = drpDay.SelectedItem.Value;
    String date = ((strMonth.Length!=2)?"0"+strMonth :strMonth)+ "/" + ((strDay.Length!=2)?"0"+strDay :strDay)+ "/" + drpYear.SelectedItem.Value;
    try
    {
        objUsers.DateOfBirth =  DateTime.ParseExact(date,"MM/dd/yyyy",System.Globalization.CultureInfo.InvariantCulture);
    }
