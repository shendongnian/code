    public void Debit(decimal amount)
    {
        decimal Account = Convert.ToDecimal(textBox1.Text);
        decimal Savings = Convert.ToDecimal(textBox3.Text);
        if ((Account + Savings) < amount)
        {
            if (Overdrawn != null)
                Owerdrawn(this, new OverdrawnEventArgs (Account, amount));
            Account = (Account + Savings) - amount;
            Savings = 0m;
        }
        ...
        textBox1.Text = Account.ToString();
        textBox2.Clear();
        textBox3.Text = Savings.ToString();
    }
