        public class UnitOfWorks : IUnitOfWorks
                    {
                         ///Context one        
                        private readonly TodosContexts todoContext = new TodosContexts();
            
                         ///Context Second
                        private readonly CustomerContext customerContext = new CustomerContext(); 
                
                        /// <summary>
                        /// Flag to show disposed of not.
                        /// </summary>
                        private bool disposed = false;
                
                        /// First context
                        private IItemRepository itemRepository;
            
                        /// Second context       
                	private ICustomerRepository customerRepository;
                
                 	    public IItemRepository ItemRepository
                        {
                            get { return this.itemRepository ?? (this.itemRepository = new  ItemRepository(this.context)); }
                        }
                
                	
                
                        public ICustomerRepository CustomerRepository
                        {
                            get { return this.customerRepository ?? (this.customerRepository = new 		               CustomerRepository(this.customerContext)); }
                        }
                    }
                
                    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
                    {
                        /// <summary>
                        /// Gets or sets CoreDBContext information.
                        /// </summary>
                        public DbContext Context { get; set; }
                
                        /// <summary>
                        /// Gets or sets Database Entity set information.
                        /// </summary>
                        public DbSet<TEntity> DBSet { get; set; }
                
                        /// <summary>
                        /// Initialises a new instance of the  <see cref="GenericRepository {TEntity}" /> class.
                        /// </summary>
                        /// <param name="contextValue">Context information.</param>
                        public GenericRepository(DbContext contextValue)
                        {
                            this.Context = contextValue;
                            this.DBSet = this.Context.Set<TEntity>();
                        }
                   }
  
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
        {
            /// <summary>
            /// Initialises a new instance of the <see cref="CommentRepository" /> class.
            /// </summary>
            /// <param name="contextValue">The context value.</param>
            public CustomerRepository(CustomerContext contextValue)
                : base(contextValue)
            {
                if (this.Context == null)
                {
                    throw new ArgumentException("Context is null.");
                }
            }
        }
