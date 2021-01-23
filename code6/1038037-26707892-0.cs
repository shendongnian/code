    cbocustinfo.Items.Clear();
    lstcustinfo.Items.Clear();
    var customers = File.ReadAllText(@"E:\AS2customers.csv")
        .Split(new []{Environment.NewLine}, StringSplitOptions.None);
    var transactions = File.ReadAllText(@"E:\AS2data.csv")
        .Split(new []{Environment.NewLine}, StringSplitOptions.None);
    foreach (var customer in customers)
    {
        var custInfo = customer.Split(',');
        var names = custInfo[0].Split(' ');
        cbocustinfo.Items.Add(names[0] + " " + names[1]+ " " + custinfo[1]);
        foreach (var transaction in transactions)
        {
            var transInfo = transaction.Split(',');
            if (custInfo[1] == transInfo[0])
            {
                lstcustinfo.Items.Add(transInfo[3] + " " + transInfo[4]);
            }
        }
    }
