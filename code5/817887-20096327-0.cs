    void DayRender(Object source, DayRenderEventArgs e)
    {
        DateTime date = e.Day.Date;  // here it is
        if(IsSpecialDay(date))  // your method to determine if a given date is a "special"-date
            e.Cell.BackColor = System.Drawing.Color.Gold;  // or use the Style property to use CSS
    } 
