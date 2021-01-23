    public class Orders
    {
        public int OrderID { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        
        public virtual Clients Clients { get; set; }
        
        public string ClientsName
        {
          if(Clients != null)
          {
             return Clients.Name
          }
          return string.Empty;
        }
    }
 
