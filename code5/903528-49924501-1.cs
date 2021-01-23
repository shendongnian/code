    using System;
    using System.Net;
    using System.Web;
    using System.Web.Http;
    ...
    [HttpPost]
    [Route("ContactForm")]
    public IHttpActionResult PostContactForm([FromBody] ContactForm contactForm)
        {
            var hostname = HttpContext.Current.Request.UserHostAddress;
            IPAddress ipAddress = IPAddress.Parse(hostname);
            IPHostEntry ipHostEntry = Dns.GetHostEntry(ipAddress);
            ...
    
