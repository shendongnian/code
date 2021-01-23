    void proxy_SendingRequest2(object sender, System.Data.Services.Client.SendingRequest2EventArgs e)
        {
            var Request = ((HttpWebRequestMessage)e.RequestMessage).HttpWebRequest;
            Request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
        }
