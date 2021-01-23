    using System;
    using System.IO;
    using System.Net;
    using System.Web;
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        private HttpWebRequest _request;
        void Page_Load(object sender, EventArgs e)
        {
            AddOnPreRenderCompleteAsync(new BeginEventHandler(BeginAsyncOperation), new EndEventHandler(EndAsyncOperation));
        } 
        
        IAsyncResult BeginAsyncOperation(object sender, EventArgs e, AsyncCallback cb, object state) 
        {
            string url = "http://example.com";
            string method = "GET";
    
            _request = (HttpWebRequest)WebRequest.Create(url);
            _request.Method = method;
    
            _request.Accept = "text/javascript, text/html, application/xml, text/xml, */*";
            _request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            _request.Host = "steamcommunity.com";
            _request.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/536.11 (KHTML, like Gecko) Chrome/20.0.1132.47 Safari/536.11";
    
            return _request.BeginGetResponse(cb, state); 
        } 
        
        void EndAsyncOperation(IAsyncResult ar) 
        { 
            string text; 
            using (WebResponse response = _request.EndGetResponse(ar))
            using (StreamReader reader = new StreamReader(response.GetResponseStream())) 
            { 
                text = reader.ReadToEnd(); 
                // TODO: do something with the result here
            } 
        }
    }
