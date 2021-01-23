      private object InvokeRest(string uri)
        {
            return InvokeRest(uri, null);
        }
        private object InvokeRest(string uri, NetworkCredential networkCredential)
        {
            var webRequest = WebRequest.Create(uri);
            if (networkCredential!=null)
                webRequest.Credentials = networkCredential;
            _webResponse = webRequest.GetResponse();
            var streamReader = new StreamReader(_webResponse.GetResponseStream());
            var str = streamReader.ReadToEnd();
            ErrorRecord exRef;
            var doc = JsonObject.ConvertFromJson(str, out exRef);
            return doc;
        }
