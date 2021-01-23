    public List<OrderLineDTO> GetLinesForOrder(int orderId)
    {
      Mapper.CreateMap<OrderLine, OrderLineDTO>()
        .ForMember(dto => dto.Item, conf => conf.MapFrom(ol => ol.Item.Name);
    
      using (var context = new orderEntities())
      {
        return context.OrderLines.Where(ol => ol.OrderId == orderId)
                 .Project().To<OrderLineDTO>().ToList();
      }
    }
