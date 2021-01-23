    WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            var   uri = new Uri(url, UriKind.Absolute);
            StringBuilder postData = new StringBuilder();
            postData.AppendFormat("{0}={1}", "userName", HttpUtility.UrlEncode(userName));
            postData.AppendFormat("&{0}={1}", "password", HttpUtility.UrlEncode(password));
            webClient.Headers[HttpRequestHeader.ContentLength] = postData.Length.ToString();
            webClient.UploadStringAsync(uri, "POST", postData.ToString());
