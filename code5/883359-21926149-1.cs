    int calculate;
    int content;
    if (Int32.TryParse(lblTotal.Content, out content))
    {
        calculate = content;
        lblTotal.Content = calculate.ToString();
    }
    else
    {
        lblTotal.Content = String.Format("Error converting {0}", lblTotal.Content);
    }
