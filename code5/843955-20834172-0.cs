    void Calendar1_DayRender(Object sender, DayRenderEventArgs e) 
          {    
             // Change the background color of the days in other Months
             // to yellow.
             if (e.Day.IsOtherMonth)
             {
                e.Cell.BackColor=System.Drawing.Color.Yellow;
             }
             if (!e.Day.IsOtherMonth) //  color to red for current month
             {
                e.Cell.BackColor=System.Drawing.Color.Red;
             }
              
    
          }
