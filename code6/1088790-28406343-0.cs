    List<decimal> prices = item.arrKFD_Price.Split(',').Select(n => decimal.Parse(n)).ToList();
    
    var max = prices.Max();
    var min = prices.Min();
    foreach (var price in prices)
    {
        var s = String.format("<td {0}>{1}</td>", GetColor(min,max,price), price); 
        sb.Append(s.ToString());
    }
    // This gets the style for the td
    private string GetColor(decimal min, decimal max, decimal p)
    {
        if (p == min)
            return "class='min'";
        
        if (p == max)
            return "class='max'";
  
        return "";
    }
