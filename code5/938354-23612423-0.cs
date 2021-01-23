    public class CorsProxyHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var url = context.Request.Headers["X-CorsProxy-Url"];
            if (url == null)
            {
                context.Response.StatusCode = 501;
                context.Response.StatusDescription =
                    "X-CorsProxy-Url was not specified. The corsproxy should only be invoked from the proxy JavaScript.";
                context.Response.End();
                return;
            }
     
            try
            {
                var request = WebRequest.CreateHttp(url);
                context.Request.CopyHeadersTo(request);
                request.Method = context.Request.HttpMethod;
                request.ContentType = context.Request.ContentType;
                request.UserAgent = context.Request.UserAgent;
                 
                if (context.Request.AcceptTypes != null)
                request.Accept = string.Join(";", context.Request.AcceptTypes);
     
                if (context.Request.UrlReferrer != null)
                    request.Referer = context.Request.UrlReferrer.ToString();
     
                if (!context.Request.HttpMethod.Equals("GET", StringComparison.OrdinalIgnoreCase))
                    context.Request.InputStream.CopyTo(request.GetRequestStream());
     
                var response = (HttpWebResponse)request.GetResponse();
                response.CopyHeadersTo(context.Response);
                context.Response.ContentType = response.ContentType;
                context.Response.StatusCode =(int) response.StatusCode;
                context.Response.StatusDescription = response.StatusDescription;
     
                var stream = response.GetResponseStream();
                if (stream != null && response.ContentLength > 0)
                {
                    stream.CopyTo(context.Response.OutputStream);
                    stream.Flush();
                }
            }
            catch (WebException exception)
            {
                context.Response.AddHeader("X-CorsProxy-InternalFailure",  "false");
     
                var response = exception.Response as HttpWebResponse;
                if (response != null)
                {
                    context.Response.StatusCode = (int)response.StatusCode;
                    context.Response.StatusDescription = response.StatusDescription;
                    response.CopyHeadersTo(context.Response);
                    var stream = response.GetResponseStream();
                    if (stream != null)
                        stream.CopyTo(context.Response.OutputStream);
     
                    return;
                }
     
                context.Response.StatusCode = 501;
                context.Response.StatusDescription = exception.Status.ToString();
                var msg = Encoding.ASCII.GetBytes(exception.Message);
                context.Response.OutputStream.Write(msg, 0, msg.Length);
                context.Response.Close();
     
            }
            catch (Exception exception)
            {
                context.Response.StatusCode = 501;
                context.Response.StatusDescription = "Failed to call proxied url.";
                context.Response.AddHeader("X-CorsProxy-InternalFailure", "true");
                var msg = Encoding.ASCII.GetBytes(exception.Message);
                context.Response.OutputStream.Write(msg, 0, msg.Length);
                context.Response.Close();
     
            }
        }
     
        public bool IsReusable { get { return true; }}
    }
