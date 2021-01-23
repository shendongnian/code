     public class order
     {
          public int id { get; set; }
          public string type { get; set; }
          public string symbol { get; set; }
          public string side { get; set; }
     }
     public class orders
     {
          List<order> order { get; set; }
     }
     JsonSerializer serializer = new JsonSerializer();
     orders myOrders = serializer.Deserialize<orders>(response);
     
     if (myOrders.order.Count() == 1)
       // we have 1 order
