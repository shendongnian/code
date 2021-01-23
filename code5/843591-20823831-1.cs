    using System;
    using System.IO;
    using System.Net;
    using System.Web;
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        private HttpWebRequest request;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AddOnPreRenderCompleteAsync(
                new BeginEventHandler(this.BeginAsyncOperation), 
                new EndEventHandler(this.EndAsyncOperation)
            );
        } 
        
        private IAsyncResult BeginAsyncOperation(object sender, EventArgs e, AsyncCallback cb, object state) 
        {
            string url = "http://example.com";
            string method = "GET";
    
            this.request = (HttpWebRequest)WebRequest.Create(url);
            this.request.Method = method;
    
            this.request.Accept = "text/javascript, text/html, application/xml, text/xml, */*";
            this.request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            this.request.Host = "steamcommunity.com";
            this.request.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/536.11 (KHTML, like Gecko) Chrome/20.0.1132.47 Safari/536.11";
    
            return this.request.BeginGetResponse(cb, state); 
        } 
        
        private void EndAsyncOperation(IAsyncResult ar) 
        { 
            using (WebResponse response = this.request.EndGetResponse(ar))
            using (StreamReader reader = new StreamReader(response.GetResponseStream())) 
            { 
                string result = reader.ReadToEnd(); 
                // TODO: do something with the result here => like binding
                // it to some Web Control or displaying it somewhere on the page
            } 
        }
    }
