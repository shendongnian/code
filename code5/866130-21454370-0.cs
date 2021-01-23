    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
           {
                DateTime input = Calendar1.SelectedDate;
                int delta = DayOfWeek.Sunday - input.DayOfWeek;
                DateTime firstDay = input.AddDays(delta);
        
                Label2.Text = string.Empty;
        
                for (int i = 0; i < 6; i++)
                    Label2.Text += ((DateTime)(firstDay.Add(new TimeSpan(i, 0, 0, 0)))).ToShortDateString() + "  ";
            }
