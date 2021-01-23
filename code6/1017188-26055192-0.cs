        {
            WebRequest request = WebRequest.Create(url); //Pass your Url here
            request.Method = "POST";
            request.ContentType = "text/xml;charset=UTF-8";
            request.Headers[HttpRequestHeader.Authorization] ="Authentication";  //Headers can be added
            request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
        }
        void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest webRequest = (HttpWebRequest)asynchronousResult.AsyncState;
            Stream postStream = webRequest.EndGetRequestStream(asynchronousResult);
            string postData = postXml;                 //Xml to be posted
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();
            webRequest.BeginGetResponse(new AsyncCallback(GetResponseCallback), webRequest);
        }
        void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)asynchronousResult.AsyncState;
                HttpWebResponse response;
                response = (HttpWebResponse)webRequest.EndGetResponse(asynchronousResult);
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(streamResponse);
                string Response = streamReader.ReadToEnd();  // Response Xml will be available here
                streamResponse.Close();
                streamReader.Close();
                response.Close();
               
            }
            catch
            {
               
            }
        }
