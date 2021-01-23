    [ResponseType(typeof(Customer))]
    public async Task<IHttpActionResult> PostCustomer(IEnumerable<Customer> customers)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        db.Customers.AddRange(customers);
        await db.SaveChangesAsync();
        return StatusCode(HttpStatusCode.Created);
    }
