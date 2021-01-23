    public class Order
    {
        public string OrderNumber {get; set;}
        public string ProductId {get; set;}
    }
    
    public List<Order> GetOrdersFromCSV(string csv)
    {
        //This should be a good place to use FileHelpers, but since the format is so simple we're going to parse it ourselves instead.
        string[] lines = csv.Replace("\r\n","\n").Split('\n'); //Split to individual lines
        List<Order> orders = new List<Order>(); //Create an object to hold the orders
        foreach(string line in lines) //Loop over the lines
        {
            Order order=new Order(); //Create an empty new order object to hold the order
            order.OrderNumber = line.Split(',')[0]; //get first column and put it in the Order as the OrderNumber
            order.ProductId = line.Split(',')[1]; //get second column
            orders.Add(order); //Add the order to the list of orders that we'll return
        }
        return orders;
    }
