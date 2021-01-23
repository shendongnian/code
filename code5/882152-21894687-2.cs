    public void RadioButtons()
    {
        if (radioButton2.Checked == true)
        {
            FinalAmount = (Amount + WeekInterestAmount);
            label10.Text = "Total Amount After 7 Days" + " " + "€" + FinalAmount.ToString("N2");
            RateChosen = WeekInterestRate;
            InterestAmount = WeekInterestAmount;
            Days = WEEK;
        }
