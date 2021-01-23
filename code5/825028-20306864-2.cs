    Dictionary<string, decimal> currencyExchange;
    if (dict.TryGetValue(comboBoxInputMoney.Text, out currencyExchange))
    {
        decimal rate;
        decimal value;
        if(decimal.TryParse(textBoxInputMoney.Text, out value)
          && currencyExchange.TryGetValue(comboBoxOutputMoney.Text, out rate))
        {
            textBoxResultMoney.Text = string.Format("{0} {1}"
                , value * rate 
                , comboBoxOutputMoney.Text);
        }
    }
