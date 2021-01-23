        public void PostWithoutResult(object objectToPost, string url) {
            var uri = new Uri(url);
            var httpPost = (HttpWebRequest)WebRequest.Create(uri);
            httpPost.KeepAlive = false;
            httpPost.Method = "POST";
            httpPost.Credentials = _credentialPool.GetNetworkCredentials(uri);
            httpPost.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(httpPost.GetRequestStream())) {
                var json = JsonConvert.SerializeObject(objectToPost);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            Task.Factory.StartNew(() => httpPost.GetResponse());
        }
