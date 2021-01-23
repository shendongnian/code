    public static Task<string> Post(string url, Encoding encoding, string content)
                {
                    var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpRequest.Method = "POST";
                    byte[] data = encoding.GetBytes(content);
                    httpRequest.ContentLength = data.Length;
        
                    TaskCompletionSource<string> result = new TaskCompletionSource<string>();
                    
        
                    Task.Factory.FromAsync<Stream>(httpRequest.BeginGetRequestStream, httpRequest.EndGetRequestStream, httpRequest)
                       .ContinueWith(requestStreamTask =>
                       {
                           try
                           {
                               using (var localStream = requestStreamTask.Result)
                               {
                                   localStream.Write(data, 0, data.Length);
                                   localStream.Flush();
                               }
        
                               Task.Factory.FromAsync<WebResponse>(httpRequest.BeginGetResponse, httpRequest.EndGetResponse, httpRequest)
                                   .ContinueWith(responseTask =>
                                   {
                                       try
                                       {
                                           using (var webResponse = responseTask.Result)
                                           using (var responseStream = webResponse.GetResponseStream())
                                           using (var sr = new StreamReader(responseStream, encoding))
                                           {
                                               result.SetResult(sr.ReadToEnd());
                                           }
                                       }
                                       catch (Exception e)
                                       {
                                           result.SetException(e);
                                       }
                                   }, TaskContinuationOptions.AttachedToParent);
                           }
                           catch (Exception e)
                           {
                               result.SetException(e);
                           }
        
                       }, TaskContinuationOptions.AttachedToParent);
        
                    return result.Task;
                }
