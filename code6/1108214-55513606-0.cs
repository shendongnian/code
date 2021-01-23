public IHttpActionResult Get()
{
    System.Web.HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
    return Ok("value");
}
