        var res = custArray.Where(c => c != null).SelectMany(c => c.Orders)
            .GroupBy(c => c.Pay.GetType().ToString())
            .Select(c => new { PayType = c.Key, Sum = c.Sum(a => a.Price * a.Quantity) });
        foreach (var re in res)
        {
            Console.WriteLine("CardType {0}, Total : {1}", re.PayType.ToString(), re.Sum);
        }
