        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri("http://www.google.de"));
        request.BeginGetResponse(ShowText, request);
        private void ShowText(IAsyncResult result)
        {
            HttpWebRequest request = (HttpWebRequest)result.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
            using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
            {
                string content = streamReader.ReadToEnd();
                Debug.WriteLine(content);
            }
        }
