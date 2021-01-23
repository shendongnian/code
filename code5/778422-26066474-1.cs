     public class WrapperHttpResponseMessageResult : ActionResult
    {
        private readonly OutgoingWebResponse _response;
        public WrapperHttpResponseMessageResult(OutgoingWebResponse response)
        {
            _response = response;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase responseContext = context.RequestContext.HttpContext.Response;
            responseContext.StatusCode = (int)_response.Status;
            responseContext.StatusDescription = _response.Status.ToString();
            foreach (string key in _response.Headers.Keys)
            {
                responseContext.AddHeader(key, _response.Headers[key]);
            }
            if (_response.Body != null)
            {
                StreamWriter escritor = new StreamWriter(responseContext.OutputStream);
                escritor.WriteAsync(_response.Body).Wait();
            }
        }
    }
