    public class ProductsController: Controller
    {
        
        protected IUnitOfWork Uow { get; set; }
        
        public ProductsController(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("Unit of Work");
            Uow = uow;
        }
    }
