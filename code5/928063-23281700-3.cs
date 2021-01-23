    var prices = new List<Pricing>();
    foreach(var item in db.JobInformations)
    {
        var price = new Pricing();
        price.ID = item.ID;
        price.Manufac = item.Manufac;
        price.Model = item.Model;
        price.Service = item.Service;
        price.Price = ((int)item.MarkupCostCents + (int)item.LaborCostCents + (int)item.HardwareCostCents) / 100;
        prices.Add( price );
    }
    return View(prices);
