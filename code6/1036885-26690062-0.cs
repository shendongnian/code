    DropDownListDate.Items.Add(DateTime.Now.ToShortDateString()); //for adding current date
        for (int i = 1; i <= 59; i++) //loop to add next 60 days
        {
            DropDownListDate.Items.Add(DateTime.Now.AddDays(i).ToShortDateString());
        }
        DateTime dt = Convert.ToDateTime("09:00"); //for adding start time
        for (int i = 0; i <= 25; i++) //Set up every 30 minute interval
        {
            ListItem li2 = new ListItem(dt.ToShortTimeString(), dt.ToShortTimeString());
            li2.Selected = false;
            DropDownListTime.Items.Add(li2);
            dt = dt.AddMinutes(30);
