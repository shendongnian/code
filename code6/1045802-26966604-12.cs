    public JsonResult changeCurrency(string newCurrency, string price)
    {
        // if this is the first time then make sure current currency is set to dollar
        if (defaultCurrency == null)
        {
            defaultCurrency = "USD";
        }
        currentPrice = Convert.ToDecimal(price);
        decimal newPrice = 0;
        // see if new currency is different
        if ((newCurrency != defaultCurrency) && (currentPrice > 0))
        {
            newPrice = convertCurrency(currentPrice, newCurrency);
        }
        else
        {
            // if nothing changes
            newPrice = currentPrice;
        }
        return Json(new { currentPrice = newPrice.ToString("C"), unformattedCurrentPrice = newPrice.ToString() }, JsonRequestBehavior.AllowGet);
    }
