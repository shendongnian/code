    foreach (string s in tokens)
    {
        if (decimal.TryParse(s, out decTotal))
        {
            numbers.Add(decTotal);
            lstTotalSales.Items.Add(s);
        }
        else
        {
            lstNames.Items.Add(s);
        }
    }
