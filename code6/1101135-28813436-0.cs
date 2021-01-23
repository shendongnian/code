    public class OrderWithShipperProductService()
    {
        public ProductRepository { get; set; }
    
        public OrderWithShipperProductService(ProductRepository repo)
        {
            this.ProductRepository = repo;
        }
    
        public void AddOrderWithShipperProduct(OrderWithShipperProduct model)
        {
            var entity = Mapper.Map<TEntity>(model);
            ProductRepository.Add(entity);
        }
    }
