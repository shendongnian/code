        var selectedDays = string.Empty;
        foreach (ListItem val in cblDay.Items)
        {
        	if (val.Selected == true)
        	{
        
        		selectedDays += "'" + val.Value + "',";
        	}
        }
    
    RptRateData.Day = selectedDays.TrimEnd(new char[] { ',' });
