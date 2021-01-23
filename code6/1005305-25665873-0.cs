       protected void cal_DayRender(object sender, DayRenderEventArgs e)
            {
                var days = (List<DateTime>)Session["WorkDates"];
    
                if (!days.Contains(e.Day.Date))
                {
                    e.Day.IsSelectable = false;
                    e.Cell.Font.Strikeout = true;
                    e.Cell.BackColor = System.Drawing.Color.Chartreuse;
                }
                
            }
