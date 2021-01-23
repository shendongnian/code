    double rate;
    if (comboBoxInputMoney.Text == "USD")
    {
        if (comboBoxOutputMoney.Text == "EUR")
        {
            rate = 0.74
        }
        if (comboBoxOutputMoney.Text == "CHF")
        {
            rate = 0.92
        }
    
        double result = double.Parse(textBoxInputMoney.Text) * rate;
        textBoxResultMoney.Text = result.ToString() + comboBoxOutputMoney.Text;
    }
