        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            timePicker.Value = datePicker.Value;
            selectedTimeUtc.Text = timePicker.Value.ToString();           
        }
        private void timePicker_ValueChanged(object sender, EventArgs e)
        {
            datePicker.Value = timePicker.Value;
            selectedTimeUtc.Text = timePicker.Value.ToString();           
        }
