    [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare,
        Method = "GET",
        UriTemplate = "/ourapi/v1/admin/certificate")]
    Stream retrieveInfo();
    [AspNetCompatibilityRequirements(RequirementsMode = 
         AspNetCompatibilityRequirementsMode.Allowed)]
    public class App : IApp
    {
        public Stream retrieveInfo()
        {
            WebOperationContext ctx = WebOperationContext.Current;
            var dateValue = DateTime.UtcNow.ToString("ddd, dd MMM yyyy HH:mm:ss UTC", CultureInfo.InvariantCulture);
            string merchantId = "1234567";
            string errorCodeValue = "00";
            ctx.OutgoingResponse.ContentType = "text/plain; charset=utf-8";
            ctx.OutgoingResponse.Headers.Add("date", dateValue);
            ctx.OutgoingResponse.Headers.Add("merchant-id", merchantId);
            ctx.OutgoingResponse.Headers.Add("error-code", errorCodeValue);
            return New System.IO.MemoryStream(Encoding.UTF8.GetBytes("hello"));
        }
    }
