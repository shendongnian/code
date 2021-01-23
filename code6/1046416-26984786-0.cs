    public IHttpActionResult GetEmployee()
    {
    
       // Get employee info
       Employee emp = myDataMethod.GetSomeEmployee().Result;
    
       return Ok(emp);
    }
