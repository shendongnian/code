    public async Task<IHttpActionResult> GetEmployee()
    {
    
       // Get employee info
       Employee emp = await myDataMethod.GetSomeEmployee();
    
       return Ok(emp);
    }
