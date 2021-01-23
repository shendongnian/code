    private bool useProxy = false;
    private IWebProxy proxy;
    private IEnumerable<Uri> proxyRemoteUris;
    public IrcClient(IWebProxy proxy)
        : this()
    {
       this.useProxy = true;
       this.proxy = proxy;
    }
    private void ProxyPerformHttpConnect(Uri remoteIrcUri)
    {
      string httpConnectRequest = string.Format("CONNECT {0}:{1} HTTP/1.1\r\nHost: {2}\r\n\r\n",
        remoteIrcUri.Host, remoteIrcUri.Port, this.proxy.GetProxy(remoteIrcUri));
      byte[] httpConnectData = Encoding.ASCII.GetBytes(httpConnectRequest);
      this.stream.Write(httpConnectData, 0, httpConnectData.Length);
      bool responseReady = false;
      string responseText = string.Empty;
      // Byte-by-byte reading required, because StringReader will read more than just the HTTP response header
      do
      {
        int readByte = this.stream.ReadByte();
        if (readByte < 0)
          throw new WebException(message: null, status: WebExceptionStatus.ConnectionClosed);
        char readChar = (char)(readByte); // Only works because HTTP Headers are ASCII encoded.
        responseText += readChar;
        responseReady = responseText.EndsWith("\r\n\r\n");
      } while (!responseReady);
      int statusStart = responseText.IndexOf(' ') + 1;
      int reasonStart = responseText.IndexOf(' ', statusStart) + 1;
      int reasonEnd = responseText.IndexOfAny(new char[] { '\r', '\n'});
      HttpStatusCode responseStatus = (HttpStatusCode)(int.Parse(responseText.Substring(responseText.IndexOf(' ') + 1, length: 3)));
      if (responseStatus != HttpStatusCode.OK)
      {
        string reasonText = responseText.Substring(reasonStart, reasonEnd - reasonStart);
        if (string.IsNullOrWhiteSpace(reasonText))
          reasonText = null;
        throw new WebException(reasonText, WebExceptionStatus.ConnectFailure);
      }
      // Finished Response Header read...
    }
    private void ProxyConnectCallback(IAsyncResult ar)
    {
      try
      {
        this.client.EndConnect(ar);
        this.stream = this.client.GetStream();
        bool proxyTunnelEstablished = false;
        WebException lastWebException = null;
        foreach (Uri remoteIrcUri in this.proxyRemoteUris)
        {
          if (this.client.Connected == false)
          {
            // Re-establish connection with proxy...
            Uri proxyUri = this.proxy.GetProxy(remoteIrcUri);
            this.client.Connect(proxyUri.Host, proxyUri.Port);
          }
          try
          {
            ProxyPerformHttpConnect(remoteIrcUri);
            proxyTunnelEstablished = true;
            break;
          }
          catch (WebException webExcept)
          {
            lastWebException = webExcept;                        
          }
        }
        if (!proxyTunnelEstablished)
        {
          OnConnectFailed(new IrcErrorEventArgs(lastWebException));
          return;
        }
        this.writer = new StreamWriter(this.stream, Encoding.Default);
        this.reader = new StreamReader(this.stream, Encoding.Default);
        HandleClientConnected((IrcRegistrationInfo)ar.AsyncState);
        this.readThread.Start();
        this.writeThread.Start();
        OnConnected(new EventArgs());
      }
      catch (Exception ex)
      {
        OnConnectFailed(new IrcErrorEventArgs(ex));
      }
    }
