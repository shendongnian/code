    string postData = string.Format("--{0}\r\nContent-Disposition: 
    form-data; name=\"{1}\"\r\n\r\n{2}",
                    boundary,
                    HttpUtility.UrlEncode(param.Key),
                    HttpUtility.UrlEncode(param.Value));
