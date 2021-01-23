    private void ValidateDate()
    {
        if (lstartdate.Text == "" || lenddate.Text == "")
        {
            lwarndate.Visible = true;
            lwarndate.Text = "Dates required";
        }
    
        if (lstartdate.Text != "" || lenddate.Text != "")
        {
            if (cstart.SelectedDate > cend.SelectedDate)
            {
                lwarndate.Visible = true;
                lwarndate.Text = "Start date must be earlier than end date!";
            }else{
                lwarndate.Visible = false;
            }
            if (cend.SelectedDate != null && cstart.SelectedDate != null)
            {
                TimeSpan duration = DateTime.Parse(cend).Subtract(DateTime.Parse(cstart));
                total.Text = duration.Days;
            }
        }
    }
