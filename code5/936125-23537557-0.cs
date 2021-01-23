            List<Orders> lstOrders = new List<Orders>();
            Orders objOrders;
            for (int index = 1; index <= 10; index++)
            {
                objOrders = new Orders();
                objOrders.OrderID = index;
                objOrders.Order = "Order_" + index.ToString();
                objOrders.CustomerID = index;
                lstOrders.Add(objOrders);
            }
           
            int[] _customers = { 1, 2, 3, 4, 5 };
            List<Orders> lstFilteredOrders = new List<Orders>();
            lstFilteredOrders.AddRange(lstOrders.FindAll(x => _customers.Any(y =>y == x.CustomerID)));
