            static void Main(string[] args)
        {
            Customer[] custArray = new Customer[3];
            // First Customer
            custArray[0] = new Customer() { FirstName = "Adam", LastName = "Miles", Orders = new Order[2] };
            custArray[0].Orders[0] = new Order() { Description = "Shoes", Price = 19.99M, Quantity = 1, PayType = PayType.MasterCard };
            custArray[0].Orders[1] = new Order() { Description = "Gloves", Price = 29.99M, Quantity = 2, PayType = PayType.Visa };
            // Second Customer
            custArray[1] = new Customer() { FirstName = "Andrew", LastName = "Hart", Orders = new Order[2] };
            custArray[1].Orders[0] = new Order() { Description = "Jacket", Price = 39.99M, Quantity = 1, PayType = PayType.MasterCard };
            custArray[1].Orders[1] = new Order() { Description = "Socks", Price = 49.99M, Quantity = 1, PayType = PayType.Visa };
            decimal total = 0;
            decimal totalMaster = 0;
            decimal totalVisa = 0;
            decimal totalPaypal = 0;
            foreach (var customer in custArray)
            {
                if (customer == null) continue;
                Console.WriteLine("Customer:\n");
                Console.WriteLine("{0, 15} {1, 17}", "First Name", "Last Name");
                Console.WriteLine("{0, 11} {1, 16}", customer.FirstName, customer.LastName);
                Console.WriteLine("Orders:\n");
                decimal cust_total = 0;
                decimal cust_totalMaster = 0;
                decimal cust_totalVisa = 0;
                decimal cust_totalPaypal = 0;
                foreach (var order in customer.Orders)
                {
                    if (order == null) continue;
                    Console.WriteLine("{0, 10} {1, 10} {2, 10}{3, 15}", order.Description, order.Price, order.Quantity, order.PayType);
                    Console.WriteLine("\n\n");
                    total += order.Price * order.Quantity;
                    cust_total += order.Price * order.Quantity;
                    if (order.PayType == PayType.MasterCard)
                    {
                        totalMaster += order.Price * order.Quantity;
                        cust_totalMaster += order.Price * order.Quantity;
                    }
                    else if (order.PayType == PayType.Visa)
                    {
                        totalVisa += order.Price * order.Quantity;
                        cust_totalVisa += order.Price * order.Quantity;
                    }
                    else if (order.PayType == PayType.Paypal)
                    {
                        totalPaypal += order.Price * order.Quantity;
                        cust_totalPaypal += order.Price * order.Quantity;
                    }
                }
                Console.WriteLine("MasterCard Total: {0, 8}", cust_totalMaster);
                Console.WriteLine("Visa Total: {0, 13}", cust_totalVisa);
                Console.WriteLine("Paypal Total: {0, 8}", cust_totalPaypal);
                Console.WriteLine("Total: {0, 18}", cust_total);
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("MasterCard GrandTotal: {0, 10}", totalMaster);
            Console.WriteLine("Visa GrandTotal: {0, 13}", totalVisa);
            Console.WriteLine("Paypal GrandTotal: {0, 10}", totalPaypal);
            Console.WriteLine("GrandTotal: {0, 18}", total);
            Console.ReadLine();
        }
