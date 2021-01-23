    var dict = new Dictionary<string, Dictionary<string, decimal>>();
    var usDict = new Dictionary<string, decimal>();
    usDict.Add("EUR", 0.74m);
    usDict.Add("CHF", 0.92m);
    dict.Add("USD", usDict); 
    // and so on ...
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
