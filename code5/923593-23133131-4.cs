    public override int RowsInSection(UITableView tableview, int section)
    {
        if(section == 0)
        {
            return TodayEmails(_emailItems).Count;  //I don't know where your TodayEmails located, so added just the name of it
        }
        else if(section == 1)
        {
            return YesterdayEmails(_emailItems).Count;  // The same as for TodayEmails
        }
        else
        {
            return OtherEmails(_emailItems).Count;  // The same as for TodayEmails
        }
    }
