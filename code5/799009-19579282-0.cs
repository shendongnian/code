    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    using (var writer = new StreamWriter(request.GetRequestStream()))
    {
        writer.Write("email=" + HttpUtility.UrlEncode(email));
        writer.Write("&password=" + HttpUtility.UrlEncode(password));
    }
