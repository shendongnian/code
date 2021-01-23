    [Route("api/createcustomer")]
    [HttpPost]
    //[ResponseType(typeof(Customer))]
    public IHttpActionResult CreateCustomer()
    {
        ...
        string location = Request.RequestUri + "/" + NewCustomer.ID.ToString();
        return Created(location, new { CustomerId = NewCustomer.ID });
    }
