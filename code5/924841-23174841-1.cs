    List<Order> orders = new List<Order>(); //Orders list
    int orderNumber; //Temporary order number
    string customerName; //Temporary customer name 
    int qtyOrdered; //Temporary quantity
    for (int x = 0; x < 3; ++x) //Fill List
    {
        Console.Write("Enter Order Number: ");
        int.TryParse(Console.ReadLine(), out orderNumber); //Parse order number
        if (IsOrderNumberInUse(orderNumber, orders) == true) //Check for duplicates
        {
            Console.WriteLine("Duplicate order number");
        }
        //Get data and add to list
        GetData(out customerName, out qtyOrdered);
        orders.Add(new Order(orderNumber, customerName, qtyOrdered));
    }
    Console.ReadLine();
