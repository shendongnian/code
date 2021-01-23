    List<string> Time = new List<string>();
    
    int hourStart = 8;
    int hourFinish = 22;
    
    for (int h = hourStart; h <= hourFinish; h++)
    {
        for (int m = 0; m < 60; m = m + 15)
        {
            string hours;
            string minutes;
    
            // this section is used to format the 0 to 00
            if (h == 0)
                hours = "00";
            else
                hours = h.ToString();
    
            if (m == 0)
                minutes = "00";
            else
                minutes = m.ToString();
    
            string time = hours + ":" + minutes;
    
            Time.Add(time);
        }
    }
