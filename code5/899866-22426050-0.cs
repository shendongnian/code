    using using System.Net;
    private void button3_Click_1(object sender, EventArgs e)
    {   
            string url = string.Empty;
            string urlProtocol = "http://";
            if (!urlText.Text.Trim().Contains(urlProtocol))
                url = urlProtocol + urlText.Text;
            else
                url = urlText.Text;
            if (CheckURL(url))
            {
                Uri urlResult = new Uri(url);
                webbrowser1.Navigate(url);
            }
            else
            {
                webbrowser1.Navigate("http://google.com/search?q=" + urlText.Text);
            }
    
    }
    
    bool CheckURL(string url)
    {
       
        var req = (HttpWebRequest)HttpWebRequest.Create(url);
        bool isURLValid = false;
        req.AllowAutoRedirect = false;
        try
        {
            using (var resp = req.GetResponse())
            {
                var location = resp.Headers["Location"];
                if (!String.IsNullOrEmpty(location))
                {
                    isURLValid = true;
                }
            }
        }
        catch
        {
            isURLValid = false;
        }
        return isURLValid;  
    }
