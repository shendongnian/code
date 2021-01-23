    	StringBuilder postData = new StringBuilder();
        postData.AppendFormat("{0}={1}", "email", HttpUtility.UrlEncode("test@test.com"));
        postData.AppendFormat("&{0}={1}", "pwd1", HttpUtility.UrlEncode("password"));
        var request = (HttpWebRequest)WebRequest.Create("http://unotez.com/other/app/verifylogin.php");
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.AllowAutoRedirect = true;
        
		// magic happens here!
		// create a cookie container which will be shared across redirects
		var cookies = new CookieContainer();
        request.CookieContainer = cookies;
        using (var writer = new StreamWriter(request.GetRequestStream()))
            writer.Write(postData.ToString());
		// sync POST request here, but you can use async as well
        var response = (HttpWebResponse)request.GetResponse();
        string data;
        using (var reader = new StreamReader(response.GetResponseStream()))
            data = reader.ReadToEnd();
        Console.WriteLine(data);
        
        // Success, Welcome: Test
