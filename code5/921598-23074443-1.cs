    private IEnumerable<ReferenceViewModel> getReferences(long CustomerID)
    {
       var customerReferences = new List<ReferenceViewModel>();
       //Code to push data into CustomerReference
       return customerReferences;
    }
    public JsonResult GetReferences(long CustomerID)
    {
         return Json(customerReference(CustomerID).OrderBy(x=>x.ReferenceName));
    }
    public JsonResult MassUpdate(List<long> CustomerIDs, List<long> DocumentIDs)
    {
        var allData = CustomerIDs.SelectMany(x => customerReference(x)).OrderBy(x=>x.ReferenceName);
        return Json(alldata);
    }
