    StringBuilder cust = new StringBuilder();
    cust.AppendLine("PRODUCT\tPRICE\tDATE");
    foreach (var pro in customer.Products)
    {
        cust.AppendFormat("{0}\t${1}\t{2}", pro.Name, pro.Price, pro.Date).AppendLine();
    }
