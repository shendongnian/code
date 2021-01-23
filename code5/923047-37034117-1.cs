    private void CallCustomerCodeDynamically(CustmoerEntities1 customerEntities)
    {
        var customerCode= from customer in customerEntities.CustomerInfoes
                       orderby customer.CustomerCode ascending
                       select customer.CustomerCode;
    
        BindCodes(customerCode);
    }
    
    
    private void CallCustomerCodeDynamically(CustmoerEntities2 customerEntities)
    {
        var customerCode= from customer in customerEntities.CustomerInfoes
                       orderby customer.CustomerCode ascending
                       select customer.CustomerCode;
    
        BindCodes(customerCode);
    }
    
    private void BindCodes(IEnumerable<string> customerCode)
    {
        ddlCustomerCode.DataSource = customerCode;
        ddlCustomerCode.DataBind();
    }
