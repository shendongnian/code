    public IHttpActionResult GetCustomer(int Id)
    {
       var customer = db.Customer.Find(id));
       return Ok(new { Name = customer.CustomerName, OtherProperty = "others" });
    }
