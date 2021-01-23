     private object InvokeRest(string uri)
        {
            return InvokeRest(uri, null);
        }
        private object InvokeRest(string uri, NetworkCredential networkCredential)
        {
            var webRequest = WebRequest.Create(uri);
            if (networkCredential!=null)
            {
                webRequest.Credentials = networkCredential;
            }
            _webResponse = webRequest.GetResponse();
            var stream = ReadMemoryStream(_webResponse.GetResponseStream(), _webResponse.ContentLength);
            var httpWebResponse = _webResponse as HttpWebResponse;
            var text = Encoding.GetEncoding(httpWebResponse.CharacterSet);
            var str = text.GetString(stream.ToArray());
            ErrorRecord exRef;
            var doc = JsonObject.ConvertFromJson(str, out exRef);
            return doc;
        }
        private static MemoryStream ReadMemoryStream(Stream stream, long contentLength)
        {
            var memoryStream = new MemoryStream((int)Math.Min(contentLength, int.MaxValue));
            var num = 0L;
            var buffer = new byte[10000];
            var count = 1;
            while (0 < count)
            {
                count = stream.Read(buffer, 0, buffer.Length);
                if (0 < count)
                    memoryStream.Write(buffer, 0, count);
                num += count;
            }
            memoryStream.SetLength(num);
            return memoryStream;
        }
