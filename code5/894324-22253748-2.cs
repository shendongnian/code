    try
    {
       DateTime date = DateTime.Parse(borrower_date_txt.Text);
       int period = Int32.Parse(period_txt.Text);
       ret_date_txt.Text = date.AddDays(period).ToShortDateString();
    }
    catch(Exception ex)
    {
       //Handle parsing errors maybe
    }
