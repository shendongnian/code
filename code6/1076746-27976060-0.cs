    protected void GetBeginningDay(object sender, EventArgs e)
    {
        string userInput = TextBox1.Text;
        DateTime dateTime;
        if (DateTime.TryParse(userInput, out dateTime))
        {
            TextBox2.Text = dateTime.DayOfWeek.ToString();
        }
    }	
