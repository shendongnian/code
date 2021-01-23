    [HttpPost]
    public virtual ActionResult ExchangeRateDetails(FormCollection collection,string currencyCode)
    {
         string value = Convert.ToString(collection["DateFrom"]);
         ...
         return View();
    }   
