    for (int i = 0; i < 7; i++)
        {
            DateTime dt = DateTime.ParseExact(textboxesIn[i].Text.PadLeft(4, '0'), "HHmm", CultureInfo.InvariantCulture);
            string timestring = dt.ToString("h:mm");
            labels[i].Text = timestring;
    
            DateTime timeIn = DateTime.ParseExact(textboxesIn[i].Text.PadLeft(4, '0'), "HHmm", CultureInfo.InvariantCulture);
            DateTime timeOut = DateTime.ParseExact(textboxesOut[i].Text.PadLeft(4, '0'), "HHmm", CultureInfo.InvariantCulture);
    
            if(timeIn.Hour == 12) timeIn = timeIn.AddHours(-12);  //an easy way 
    
            if (dropdownIn[i].SelectedValue == "PM")
            {
                timeIn = timeIn.AddHours(12);
            }
    
            if (dropdownOut[i].SelectedValue == "PM")
            {
                timeOut = timeOut.AddHours(12);
            }
            labels[i].Text = (timeOut - timeIn).TotalHours.ToString("f2");
        }
