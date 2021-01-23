        public void DoLogin()
        {
            string uri = "http://localhost:62085/AuthenticationService.svc/Login";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "text/json";
            string data = "{\"username\": \"reviewer\", \"password\": \"456\", \"applicationName\": \"123\"}";
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] bytes = encoding.GetBytes(data);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                // Send the data.
                requestStream.Write(bytes, 0, bytes.Length);
            }
            using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(x))
            {
                using(var responseStream = response.GetResponseStream())
                {
                    using(var reader = new StreamReader(responseStream))
                    {
                        //Here you will get response
                        string loginResponse = reader.ReadToEnd();
                    }
                    
                }
            }
        }
