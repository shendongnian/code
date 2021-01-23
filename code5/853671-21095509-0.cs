    try
    {
        Order o = IoC.Resolve<IOrderService>().GetOrderById(orderID);
        Customer ThisCustomer = o.Customer;
    
        // Specify file, instructions, and privelegdes
        string path = System.Web.HttpContext.Current.Request.PhysicalPath;
        int index = path.IndexOf("\\Administration");
        string realPath = Path.Combine(path.Substring(0, index), "FedEx",
            orderID.ToString(), ".txt");
        FileStream file = new FileStream(realPath,
            FileMode.OpenOrCreate,
            FileAccess.Write);
    }
