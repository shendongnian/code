		Uri uri = new Uri("https://foo.com/");
        ServicePoint servicePoint = ServicePointManager.FindServicePoint(u);
        HttpWebRequest request = HttpWebRequest.Create(uri) as HttpWebRequest;
        request.Accept = "*/*";
        request.ConnectionGroupName = "fooGroopName";
        using (WebResponse response = request.GetResponse())
        {            
		   ...
        }
        servicePoint.CloseConnectionGroup("fooGroopName");
        var cert = servicePoint.Certificate;
