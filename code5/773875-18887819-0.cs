    private static void Main(string[] args)
            {
                var allOrders = BuildOrders();
    
                Order tempOrder;
                for (int i = 0; i < 12; i++)
                {
                    tempOrder =  allOrders.Pop();
                    Console.WriteLine("Order Name :{0} Date: {1}", tempOrder.Name, tempOrder.Date);
                    if (counter >= 12)
                        break;
                }
            }
    
            private static Stack<Order> BuildOrders()
            {
                Stack<Order> allOrders = new Stack<Order>();
                for (int i = 0; i < 30; i++)
                {
                    Order order = new Order("Order" + i, new DateTime(2013, 1, 1).AddDays(i));
                    allOrders.Push(order);
                }
                return allOrders;
            }
