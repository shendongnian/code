    public void Run()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                Console.WriteLine("StackLight Web Server is running...");
                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem((c) =>
                        {
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                // set the content type
                                ctx.Response.Headers[HttpResponseHeader.ContentType] = SetContentType(ctx.Request.RawUrl);
                                WebServerRequestData data = new WebServerRequestData();
                                // store html content in a byte array
                                data = _responderMethod(ctx.Request);
                                string res = "";
                                if(data.ContentType.Contains("text"))
                                {
                                    char[] chars = new char[data.Content.Length/sizeof(char)];
                                    System.Buffer.BlockCopy(data.Content, 0, chars, 0, data.Content.Length);
                                    res = new string(chars);
                                    data.Content = Encoding.UTF8.GetBytes(res);
                                }
                                // this writes the html out from the byte array
                                ctx.Response.ContentLength64 = data.Content.Length;
                                ctx.Response.OutputStream.Write(data.Content, 0, data.Content.Length);
                            }
                            catch (Exception ex)
                            {
                                ConfigLogger.Instance.LogCritical(LogCategory, ex);
                            }
                            finally
                            {
                                ctx.Response.OutputStream.Close();
                            }
                        }, _listener.GetContext());
                    }
                }
                catch (Exception ex)
                {
                    ConfigLogger.Instance.LogCritical(LogCategory, ex); 
                }
            });
        }
