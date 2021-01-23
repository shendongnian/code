    private List<ReferenceViewModel> getReferences(long CustomerID)
    {
       var customerReferences = new List<ReferenceViewModel>();
       //Code to push data into CustomerReference
       return customerReferences.OrderBy(x=>x.ReferenceName).ToList();
    }
    public JsonResult GetReferences(long CustomerID)
    {
         return Json(customerReference(CustomerID));
    }
    public JsonResult MassUpdate(List<long> CustomerIDs, List<long> DocumentIDs)
    {
        var allData = CustomerIDs.SelectMany(x => customerReference(x));
        return Json(alldata);
    }
