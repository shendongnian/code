    protected void TextBox14_TextChanged(object sender, EventArgs e)
        {
            // Not sure if you are subtracting old from new or new from old but you can sorta that out
            Label20.Text = ((TimeSpan)(Calendar2.SelectedDate - Calendar1.SelectedDate)).TotalDays.ToString();
        }
