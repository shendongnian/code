            decimal loan;        // Monthly cost of loan
            decimal insurance;   // Monthly insurance cost
            decimal gas;         // Monthly gas cost
            decimal oil;         // Monthly oil cost
            decimal tires;       // Monthly tire cost
            decimal maintenance; // Monthly maintenance cost
            decimal monthlyCost; // Monthly total cost
            // Get the loan amount.
            loan = decimal.Parse(loanTextBox.Text);
            // Get the insurance amount.
            insurance = decimal.Parse(insTextBox.Text);
            // Get the gas amount.
            gas = decimal.Parse(gasTextBox.Text);
            // Get the oil amount.
            oil = decimal.Parse(oilTextBox.Text);
            // get the tires amount.
            tires = decimal.Parse(tiresTextBox.Text);
            // Get the maintenance amount.
            maintenance = decimal.Parse(mainTextBox.Text);
            // determine the monthly cost.
           
            // Calculate monthly cost.
            monthlyCost = loan + insurance + gas + oil + tires + maintenance;
            totalMonthlyLabel.Text = monthlyCost.ToString();
