    protected void EndDate_OnSelectionChanged(object sender, EventArgs e) //COMPARE VALIDATOR FOR EXAM DATE
    {
        CustomValidator1.IsValid = true;
        DateTime SelectedDate = EndDate.SelectedDate.Date;
        DateTime NowDate = DateTime.Now;
        tb_date.Text = SelectedDate.ToShortDateString();
        if (SelectedDate.Date > NowDate.Date)
        {
            CustomValidator1.IsValid = false;
        }
    }
