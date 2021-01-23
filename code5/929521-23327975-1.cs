    [Route("getProtectedThing")]
    public IHttpActionResult Get()
    {
       if(ClaimsPrinciple.Current.Claims.First(x => x.Type == ClaimsTypes.NameIdentifier).Value 
            == orderId.memberId || 
            ClaimsPrinciple.Current.Claims.FirstOrDefault(x => x.Type == "IsAdmin").Value)
       {
          return Ok("data");
       }
       return Unauthorized();
    }
