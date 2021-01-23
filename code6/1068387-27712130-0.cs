    WebReference.getCustomer cust = new WebReference.getCustomer();
    cust.customerNumber = 123456; //pass customer number
    WebReference.AccountService acService = new WebReference.AccountService();
    WebReference.getCustomerResponse acServiceResponce = acService.getCustomer(cust); //pass object of getCustomer class to getCustomer method  
    string address1 = acServiceResponce.getCustomerResult.Address1;
    string city = acServiceResponce.getCustomerResult.City;
