    private void yearCombo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(int.Parse(yearCombo.Text) > DateTime.Now.Year)
        {
            //remove all entries from ComboBox
        }
        else if (int.Parse(yearCombo.Text) == DateTime.Now.Year)
        {
            //Just add the months up to current month
        }
        else
        {
            //Add all months
        }
    }
