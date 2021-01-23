    Uri fileDownloadURI = new Uri(fileDownloadUrl);
	HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fileDownloadURI);
	request.Headers[HttpRequestHeader.Authorization] = "Bearer " + authorization;
	var authCookie = FormsAuthentication.GetAuthCookie(User.Identity.Name, true);
	Cookie requestAuthCoockie = new Cookie()
	{
		Expires = authCookie.Expires,
		Name = authCookie.Name,
		Path = authCookie.Path,
		Secure = authCookie.Secure,
		Value = authCookie.Value,
		Domain = fileDownloadURI.Host,
		HttpOnly = authCookie.HttpOnly,
	};
	request.CookieContainer = new CookieContainer();
	request.CookieContainer.Add(requestAuthCoockie);
	HttpWebResponse response = (HttpWebResponse)request.GetResponse();
