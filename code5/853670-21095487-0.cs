    try
    {
        Order o = IoC.Resolve<IOrderService>().GetOrderById(orderID);
        Customer ThisCustomer = o.Customer;
    
        // Specify file, instructions, and privelegdes
        string path = System.Web.HttpContext.Current.Request.PhysicalPath;
        int index = path.LastIndexOf("\\");
        string realPath = path.Substring(0, index + 1);
        FileStream file = new FileStream(realPath + "/../FedEx/" +
            orderID.ToString() + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
    }
