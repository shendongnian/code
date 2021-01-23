    public string PostMethod(byte[] bytes)
        {
            string postUrl = "https://asr.yandex.net/asr_xml?" +
            "uuid=01ae13cb744628b58fb536d496daa1e6&" +
            "key="+your_api_key_here+"&" +
            "topic=queries";
 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
            request.Method = "POST";
            request.Host = "asr.yandex.net";
            request.SendChunked = true;
            request.UserAgent = "Oleg";
 
            request.ContentType = "audio/x-pcm;bit=16;rate=16000";
            request.ContentLength = bytes.Length;
 
            using (var newStream = request.GetRequestStream())
            {
                newStream.Write(bytes, 0, bytes.Length);
            }
 
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseToString = "";
            if (response != null)
            {
                var strreader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                responseToString = strreader.ReadToEnd();
            }
 
            int index = responseToString.IndexOf("<variant confidence=\"1\">");
 
            responseToString = responseToString.Substring(index + 24, responseToString.Length - index - 24);
 
            int index2 = responseToString.IndexOf("</variant>");
 
            responseToString = responseToString.Substring(0, index2);
 
            return responseToString;
        }
