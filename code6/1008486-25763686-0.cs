     private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            var month = dateTimePicker1.Value.Month;
            var weekNumberThisMonth = (dateTimePicker1.Value.Day + (7 - (int)dateTimePicker1.Value.DayOfWeek)) / 7;
            txtweek.Text = Convert.ToString(weekNumberThisMonth);
        }
