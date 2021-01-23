    public class OrderDataEntry
    {
        public static void TakeOrder()
        {
            Console.Write("\nWhich number from the menu do you wish to order?");
            int orderNo = int.Parse(Console.ReadLine());
            Menu menukort = new Menu();
            Pizza wantedPizza = menukort.pizzaOnMenu.FirstOrDefault<Pizza>(p => p.OrderNumber.Equals(orderNo));
            if (wantedPizza != null)
            {
                Console.WriteLine("\n" + wantedPizza.PizzaName + " is added to your order");
                Order o = new Order(wantedPizza);
            }
            else
            {
                Console.WriteLine("\nThe pizza with no. " + orderNo + " was not found!");
            }
        }
    }
    public class Order
    {
        private List<Pizza> orderList; 
        public Order(Pizza wantedPizza)
        {
            orderList = new List<Pizza>();
            AddToOrder(wantedPizza);
        }
        public void AddToOrder(Pizza wantedPizza)
        {
            orderList.Add(wantedPizza);
        }
    }
