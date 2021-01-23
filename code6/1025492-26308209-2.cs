    public class CookieAwareWebClient : WebClient
    {
        private readonly CookieContainer m_container = new CookieContainer();
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            HttpWebRequest webRequest = request as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.CookieContainer = m_container;
            }
            return request;
        }
    }
    // ...
    private void button2_Click(object sender, EventArgs e)
    {
        string URI = "http://localhost/post.php";
        string myParameters = "field=value1&field2=value2";
        using (WebClient wc = new CookieAwareWebClient())
        {
            string getpage = wc.DownloadString("http://localhost/post.php");
            MessageBox.Show(getpage);
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string HtmlResult = wc.UploadString(URI, myParameters);
            MessageBox.Show(HtmlResult);
        }
    }
