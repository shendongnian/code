    public static class WebRequestExtensions
    {
        public static WebResponse GetWEResponse(this WebRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
    
            try
            {
                return request.GetResponse();
            }
            catch (WebException e)
            {
                return e.Response;
            }
        }
    }
