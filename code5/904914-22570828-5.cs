     byte[] credentialBuffer = new UTF8Encoding().GetBytes(username + ":" + password);
     string authToken = Convert.ToBase64String(credentialBuffer);
     string authHeaderValue = string.Format(System.Globalization.CultureInfo.InvariantCulture, "Basic {0}", authToken);
     HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create("https://TESTRestAPI/service/1/sub");
     request.Headers.Add(HttpRequestHeader.Authorization, authHeaderValue);
