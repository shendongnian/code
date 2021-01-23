    public JsonResult ThreeLevel_OrderDetailsDataRequested(string parentRowID)
    {    
        //Code
        var orderDetails = from o in myDbModel.MyCustomerOrderDetails
    		 where o.OrderID == Convert.ToInt32(parentRowID)
    		 and o.CustomerId == customerId //static global variable
    		 select o;
    
        //Code
    }
