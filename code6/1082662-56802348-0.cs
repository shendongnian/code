    app.UseDeveloperExceptionPage();
                    var webProxy = new WebProxy(new Uri(Configuration["defaultProxy:proxyaddress"]), BypassOnLocal: false);
                    var proxyHttpClientHandler = new HttpClientHandler
                    {
                        Proxy = webProxy,
                        UseProxy = true,
                    };
                    AppContext.SetSwitch("System.Net.Http.UseSocketsHttpHandler", false);
