    public ActionResult Categories(int productId)
    {
       // populate view model based on  product Id
       return PartialView("_Categories", viewmodel);
    
    }
