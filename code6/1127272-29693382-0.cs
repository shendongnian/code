            HttpWebRequest webRequest = WebRequest.CreateHttp(yourRequest.RequestUri);
            webRequest.Method = yourRequest.Method;
            
            // HttpWebRequest does not change when assigning, have to assign base class
            ((WebRequest)webRequest).ContentType = client.Headers.ContentType;
            if (yourRequest.RequestString != null)
            {
                // For Windows Phone 8.1 to work
                if (webRequest.Headers.AllKeys.Contains("Content-Length"))
                {
                    webRequest.Headers[HttpRequestHeader.ContentLength] = yourRequest.RequestString.Length.ToString();
                }
                // This is for Windows 8.1 to work
                byte[] arrData = Encoding.UTF8.GetBytes(yourRequest.RequestString);
                using (Stream dataStream = await webRequest.GetRequestStreamAsync())
                {
                    dataStream.Write(arrData, 0, arrData.Length);
                }
            }
