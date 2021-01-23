    protected void Page_Load(object sender, EventArgs e)
            {   
    WebRequest request = WebRequest.Create("https://192.168.1.118/PracticeWcfService1/Service1.svc/RestTypeWithSecure/GetProductData");
                    ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
                    WebResponse ws = request.GetResponse();
            string text;
    using (var sr = new StreamReader(ws.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
    }
            
            Response.write(text );
    }
