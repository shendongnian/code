    private void yearCombo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Assuming you're not having 2015 and above in the years combo
        if(yearCombo.Text == DateTime.Now.Year.ToString())
        {
            //Just add the months up to current month
        }
        else
        {
            //Add all months
        }
    }
