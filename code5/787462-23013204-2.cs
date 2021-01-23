    public class CustomerEntityRepository : Repository<CustomerEntity>, ICustomerEntityRepository
        {
            public CustomerEntityRepository( IDbConnectionFactory dbFactory )
                : base(dbFactory)
            {
            }
        }
    }
