                try {
                    var request = (HttpWebRequest)callbackResult.AsyncState;
                    using (var response = request.EndGetResponse(callbackResult))
                    using (var stream = response.GetResponseStream()) {
                        bool zip = false;
                        if (response.Headers.AllKeys.Contains("Content-Encoding") &&
                            response.Headers[HttpRequestHeader.ContentEncoding].ToLower() == "gzip") zip = true;
                        using (var reader = zip ?
    #if NETFX_CORE
                            new StreamReader(new GZipStream(stream, CompressionMode.Decompress))
    #else
                            new StreamReader(new zlib.ZOutputStream(stream), false)
    #endif
                            : new StreamReader(stream)) {
                            var str = reader.ReadToEnd();
                            result = new ObjectResult(str);
                        }
                    }
                } 
    catch (WebException e) {...}
