        if (e.Day.IsWeekend)
        {
            e.Day.IsSelectable = false;
            e.Cell.BackColor = System.Drawing.Color.Yellow;
        }
        
        if(e.Day.Date.Day%2==0 && !e.Day.IsOtherMonth && !e.Day.IsWeekend)
        {
            e.Day.IsSelectable = false;
            e.Cell.BackColor = System.Drawing.Color.Orange;
            e.Cell.ToolTip = "Booked";
        }
        if (e.Day.Date.Day % 2 != 0 && !e.Day.IsOtherMonth && !e.Day.IsWeekend)
        {
            e.Day.IsSelectable = false;
            e.Cell.BackColor = System.Drawing.Color.PaleGreen;
            e.Cell.ToolTip = "Available";
        }
        if(e.Day.Date.Day%5==0 && !e.Day.IsOtherMonth && !e.Day.IsWeekend )
        {
            e.Day.IsSelectable = false;
            e.Cell.BackColor = System.Drawing.Color.Green;
            e.Cell.ToolTip = "Fast Booking";
        }
    }
