    DateTime borrowerDate;
    if (DateTime.TryParse(borrower_date_txt.Text, out borrowerDate))
    {
        int days;
        if (int.TryParse(period_txt.Text, out days))
        {
            var retDate = borrowerDate.AddDays(days);
            ret_date_txt.Text = retDate.ToShortDateString();
        }
    }
