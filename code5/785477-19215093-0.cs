        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) {
            if (e.Start.DayOfWeek == DayOfWeek.Monday) {
                MessageBox.Show("I hate mondays");
                monthCalendar1.SelectionStart = e.Start.AddDays(1);
            }
        }
