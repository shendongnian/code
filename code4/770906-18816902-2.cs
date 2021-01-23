    [Route("/customers/{Id}")]
    public class GetCustomer : IReturn<CustomerDTO>
    {
        public int Id { get; set; }
    }
    [Route("/customers")]
    public class GetCustomers : IReturn<IEnumerable<CustomerDTO>>
    {
        public string LastName { get; set; }
    }
