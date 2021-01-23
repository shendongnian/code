    public void StartNewThread()
            {
                    Thread thread = new Thread(StartListening);
                    thread.Start();
            }
                        
            public void StartListening()
            {
                        HttpListener listener = new HttpListener();
                        
                        string hostAddress = Dns.GetHostAddresses(Environment.MachineName)[1].ToString();
                        
                        if (hostAddress == "[::1]" || hostAddress == "::1") { hostAddress = "127.0.0.1"; }
                        
                        String[] prefixes = new String[] { 
                                 "http://localhost:1234/camera/", 
                                 "http://" + hostAddress + ":1234/camera/" ,
                                 "http://" + Environment.MachineName + ":1234/camera/" };
                        
                        int ii = 0;
                        
                        foreach (string s in prefixes)
                        {
                            listener.Prefixes.Add(s);
                            ii++;
                        }
                        
                    while (true)
                    {
                
                // When button clicked in Web Form for playing camera 1, Windows form application will catch it here
                        HttpListenerContext context = listener.GetContext();
                        HttpListenerRequest request = context.Request;
                        
                        String url = request.RawUrl;
                        String[] subUrlArray = url.Split('/');
                        String queryString = subUrlArray[2];
                        
                        HttpListenerResponse response = context.Response;
                        
                        if (queryString == "play")
                        {
                             if (subUrlArray.Length > 2 && subUrlArray[3] != "")
                             {
                                 if(subUrlArray[3] == "1")
                                 {
                                     // Code for starting to play Camera 1
                                 }
                                 else if(subUrlArray[3] == "2")
                                 {
                                     // Code for starting to play Camera 2
                                 }
                             }                
                        }
                        else if (queryString == "stop")
                        {
                            if (subUrlArray.Length > 2 && subUrlArray[3] != "")
                             {
                                 if(subUrlArray[3] == "1")
                                 {
                                     // Code for stopping Camera 1
                                 }
                                 else if(subUrlArray[3] == "2")
                                 {
                                     // Code for stopping Camera 2                                }
                               }
                             }     
                        }
                     }
                }
