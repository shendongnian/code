    var customer = (from cus in _billingCommonservice.BillingUnit.CustomerRepository.GetAll()  
                              join man in _billingCommonservice.BillingUnit.FunctionRepository.ManagersCustomerValue()  
                              on cus.CustomerID equals man.CustomerID  
                              // start left join  
                              into a  
                              from b in a.DefaultIfEmpty(new DJBL_uspGetAllManagerCustomer_Result() )  
                              select new { cus.MobileNo1,b.ActiveStatus });  
