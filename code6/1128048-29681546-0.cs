    using (WebClient client = new WebClient())
    {
        NameValueCollection vals = new NameValueCollection();
        vals.Add("myname", "bob");
        client.UploadValues("http://www...../testform1.aspx", vals);                
    }
