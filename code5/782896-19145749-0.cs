    public class OrderDetails : OrderList
    {
          public string CompanyId { get; set; }
          public virtual ICollection<OrderItems> OrdItems { get; set; }
    }
