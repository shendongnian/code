    ...
    for (int x = 0; x < 3; ++x) //Fill List
    {
        orderNumber = AskForOrderNumber(orders);
        //Get data and add to list
        GetData(out customerName, out qtyOrdered);
        orders.Add(new Order(orderNumber, customerName, qtyOrdered));
        }
        Console.ReadLine();
    }
    private static int AskForOrderNumber(List<Order> orders)
    {
        int orderNumber;
        Console.Write("Enter Order Number: ");
        int.TryParse(Console.ReadLine(), out orderNumber); //Parse order number
        if (IsOrderNumberInUse(orderNumber, orders) == true) //Check for duplicates
        {
            Console.WriteLine("Duplicate order number");
            AskForOrderNumber(orders);
        }
        return orderNumber;
    }
