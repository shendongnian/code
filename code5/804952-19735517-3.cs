    public class OrderLine
    {
      public int Id { get; set; }
      public int OrderId { get; set; }
      public Item Item { get; set; }
      public decimal Quantity { get; set; }
    }
    
    public class Item
    {
      public int Id { get; set; }
      public string Name { get; set; }
    }
    
    public class OrderLineDTO
    {
      public int Id { get; set; }
      public int OrderId { get; set; }
      public string Item { get; set; }
      public decimal Quantity { get; set; }
    }
    
    public class OrderDAL
    {
        static OrderDAL()
        {
            Mapper.CreateMap<OrderLine, OrderLineDTO>()
                .ForMember(dto => dto.Item, conf => conf.MapFrom(ol => ol.Item.Name);
        }
        public List<OrderLineDTO> GetLinesForOrder(string itemName)
        {
          using (var context = new orderEntities())
          {
            return context.OrderLines.Project().To<OrderLineDTO>()
                   .Where(i => i.Name == itemName).ToList();
          }
        }
    }
