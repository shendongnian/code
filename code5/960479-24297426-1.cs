    public class CreatedCustomerResponse
    {
        public int CustomerId { get; set; }
    }
    [Route("api/createcustomer")]
    [HttpPost]
    [ResponseType(typeof(CreatedCustomerResponse))]
    public IHttpActionResult CreateCustomer()
    {
        ...
        string location = Request.RequestUri + NewCustomer.ID.ToString();
        return Created(location, new CreatedCustomerResponse { CustomerId = NewCustomer.ID });
    }
