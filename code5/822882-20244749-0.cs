    int padding = 30 - item.ProductName.Length;
    string prodName = item.ProductName.PadRight(padding, ' ');
    string quant = String.Format("{0,15}", item.GetQuantity);
    string price = String.Format("{0,30:C2}", item.LatestPrice);
    string total = String.Format("{0,30:C2}", item.TotalOrder);
    string temp = prodName + quant + price + total;
    return temp;
