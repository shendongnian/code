    class Program
    {
     static void Main(string[] args)
     {
         List<Order> orders = new List<Order>();
         orders.Add(new Order { Sku = "ABC", Qty = 10});
     }
    }
    public class Order {
     public String Sku { get; set; }
     public int Qty { get; set; }
    }
