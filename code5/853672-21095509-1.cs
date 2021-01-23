    try
    {
        Order o = IoC.Resolve<IOrderService>().GetOrderById(orderID);
        Customer ThisCustomer = o.Customer;
    
        // Specify file, instructions, and privelegdes
        string path = System.Web.HttpContext.Current.Request.PhysicalPath;
        // this should give me the index at which the "\administration" part of the
        // path starts so we can cut it off
        int index = path.IndexOf("\\administration",
            StringComparison.OrdinalIgnoreCase);
        // when building the path we substring from 0 to the index of the
        // "\administration" part of the string, add "FedEx", the order id,
        // and then finally ".txt"
        string realPath = Path.Combine(path.Substring(0, index), "FedEx",
            orderID.ToString(), ".txt");
        // now open the file
        FileStream file = new FileStream(realPath,
            FileMode.OpenOrCreate,
            FileAccess.Write);
    }
