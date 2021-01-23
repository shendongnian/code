    private void yearCombo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(int.Parse(yearCombo.Text) > DateTime.Now.Year)
        {
            //remove all entries from ComboBox
            this.month_list.Items.Clear();
        }
        else if (int.Parse(yearCombo.Text) == DateTime.Now.Year)
        {
            //Just add the months up to current month
            this.month_list.Items.Clear();
            int monthnumber = 1;
            while(monthnumber <= DateTime.Now.Month)
            {
                this.month_list.Items.Add(months[monthnumber]);
                monthnumber++;
            }
        }
        else
        {
            //Add all months
            this.month_list.Items.Clear();
            int monthnumber = 1;
            while(monthnumber <= 12)
            {
                this.month_list.Items.Add(months[monthnumber]);
                monthnumber++;
            }
            
        }
    }
