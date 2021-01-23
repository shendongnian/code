    [Route("getProtectedThing")]
    public IHttpActionResult Get()
    {
       var order = getOrder(orderId);
       if(ClaimsPrinciple.Current.Claims.First(x => x.Type == ClaimsTypes.NameIdentifier).Value 
            == order.memberId || 
            ClaimsPrinciple.Current.Claims.FirstOrDefault(x => x.Type == "IsAdmin").Value)
       {
          return Ok("data");
       }
       return Unauthorized();
    }
