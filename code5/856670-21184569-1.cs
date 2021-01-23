    string goodQualityColor = "Green";
    string badQualityColor = "Red";
    string notCheckedColor = "Gray";
    string notCheckedStatus = "Not Checked";
    string failedStatus = "Failed";
    string passedStatus = "Passed";
    Dictionary<int,string> results= new Dictionary<int,string>();
    results.Add(2,goodQualityColor);
    results.Add(1,badQualityColor);
    results.Add(0,notCheckedColor);
    Dictionary<int,string> qualityStatuses = new Dictionary<int,string>();
    results.Add(2,passedStatus);
    results.Add(1,failedStatus);
    results.Add(0,notCheckedStatus);
    var request = (from product in context.Product
                  join productCheck in context.ProductCheckList
                  on product.productId equals productCheck.productID
                  select new
                  {
                     Product = product,
                     QualityStatus = product.Result,
                     Result = product.Result
                  }).ToList();
    var finalResults = (from req in request
                        select new ProductWrapper
                        {
                          Product = req.Product,
                          QualityStatus = qualityStatuses.FirstOrDefault(s => s.Key == req.QualityStatus).Value,
                          BgColor = results.FirstOrDefault (s => s.Key == req.Result).Value  
                        }).ToList<ProductWrapper>(); 
