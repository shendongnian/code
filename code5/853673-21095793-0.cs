    try
    {
        Order o = IoC.Resolve<IOrderService>().GetOrderById(orderID);
        Customer ThisCustomer = o.Customer;
    
        // Specify file, instructions, and privelegdes
        string path = System.Web.HttpContext.Current.Request.PhysicalPath;
        FileStream file = new FileStream("C:/Users/user2/Desktop/work/SuperBy/nop/NopCommerceStore/FedEx/" + orderID.ToString() + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
    }
