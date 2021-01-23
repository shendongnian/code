    [HttpPost]
    public ActionResult ClientOrderDetail(FormCollection collection, string EncodedResponse)
    {
        Boolean Validation = myFunction.ValidateRecaptcha(EncodedResponse);
            
        return View();
    }
