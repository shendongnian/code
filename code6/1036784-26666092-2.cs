    string param = "username=MyUserName&password=123456";
	string url = "https://lms.nust.edu.pk/portal/login/index.php";
	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
	request.Method = "POST";
	request.ContentLength = param.Length;
	request.ContentType = "application/x-www-form-urlencoded";
	request.CookieContainer = new CookieContainer();
	
	using (Stream stream = request.GetRequestStream())
	{
		byte[] paramAsBytes = Encoding.Default.GetBytes(param);
		stream.Write(paramAsBytes, 0, paramAsBytes.Count());
	}
	
	using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
	{
		foreach (var cookie in response.Cookies)
		{
			var properties = cookie.GetType()
                                   .GetProperties()
                                   .Select(p => new 
                                   { 
                                       Name = p.Name, 
                                       Value = p.GetValue(cookie) 
                                   });
			foreach (var property in properties)
			{
				Console.WriteLine ("{0}: {1}", property.Name, property.Value);
			}
		}
	}
