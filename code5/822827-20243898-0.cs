    if (lunchRadioButton.Checked == true)
    {
        Meal = Lunch;
        if (tableCheckBox.Checked && waiterCheckBox.Checked)
        {
            Extras = Waiter + Table;
        }
        else if (waiterCheckBox.Checked)
        {
            Extras = Waiter;
        }
        else if (tableCheckBox.Checked)
        {
            Extras = Table;
        }
    }
        
