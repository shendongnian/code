    public class CustomerNameTransformer : AbstractTransformerCreationTask<Customer>
    {
        public CustomerNameTransformer()
        {
            TransformResults = results => from customer in results
                                          select new CustomerNameViewModel
                                          {
                                              Id = customer.Id,
                                              Name = customer.Name
                                          };
        }
    }
