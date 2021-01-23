    // I hate the VS-generated event names, but...
    private void btn_deposit_Click(object sender, EventArgs e)
    {
        // TODO: Use decimal.TryParse, and handle invalid input cleanly.
        decimal newDeposit = decimal.Parse(putin.Text);
        account.Deposit(newDeposit);
        aMtBox.Text = account.AccountBalance.ToString();
    }
