     byte[] credentialBuffer = new UTF8Encoding().GetBytes(Username + ":" + Password);
     string AuthToken = Convert.ToBase64String(credentialBuffer);
     string AuthHeaderValue = string.Format(System.Globalization.CultureInfo.InvariantCulture, "Basic {0}", AuthToken);
     HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(sAddress);
     request.Headers.Add(HttpRequestHeader.Authorization, AuthHeaderValue);
