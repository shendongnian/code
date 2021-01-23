    decimal loan;        // Monthly cost of loan
    decimal insurance;   // Monthly insurance cost
    decimal gas;         // Monthly gas cost
    decimal oil;         // Monthly oil cost
    decimal tires;       // Monthly tire cost
    decimal maintenance; // Monthly maintenance cost
    decimal monthlyCost; // Monthly total cost
    try
    {
        loan = decimal.Parse(loanTextBox.Text);
        insurance = decimal.Parse(insTextBox.Text);
        gas = decimal.Parse(gasTextBox.Text);
        oil = decimal.Parse(oilTextBox.Text);
        tires = decimal.Parse(tiresTextBox.Text);
        maintenance = decimal.Parse(mainTextBox.Text);
        monthlyCost = loan + insurance + gas + oil + tires + maintenance;
        TotalMonthlyLabel.Text = monthlyCost.ToString();// Display the monthlyCost in the correct control.
    }
    catch { }
