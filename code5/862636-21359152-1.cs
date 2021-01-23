        private void setDepositButton_Click(object sender, EventArgs e)
        {
            double setInitial = double.Parse(setDepositTextBox.Text);
            bankForm = new BankAccount(setInitial);
            listBox.Items.Add(setInitial);
        }
