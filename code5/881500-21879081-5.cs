    public static class AutoMapperConfig
    {
      public static void Configure()
      {
        Mapper.CreateMap<OrderDetails, OrderDetailViewModel>;
      }
    }
