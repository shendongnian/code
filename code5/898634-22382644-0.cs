    [HttpPost]
    [ActionName("alias_for_action")]
    public HttpResponseMessage PostProduct([FromBody] Product item)
    {
    
       //your code here
     
       var response = new HttpResponseMessage(HttpStatusCode.Created)
       {
           Content = new StringContent("Your Result")
       };
    
       return response;
    }
