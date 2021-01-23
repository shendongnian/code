    public ActionResult Virtualization_Read([DataSourceRequest] DataSourceRequest request)
    {
    			var CustomerData = (from cp in context.CustomerProfile select cp); // don't call toList() this exectues the SQL and pulls data into memory, leave it as a Queryable object so we can pass it to kendo to add its expressions this will the be a Database operation
    			
    			DataSourceResult result = CustomerData.ToDataSourceResult(request, x => new CustomerProfileModel(){
    						CustomerID = x.CustomerID;
    						AccountNumber = x.AccountNumber;
    						ComapnyName = x.ComapnyName;
    						ContactPerson = x.ContactPerson;
    						UserId = x.UserId;
    				});
    			
    		
    		
                return Json(result);
    }
