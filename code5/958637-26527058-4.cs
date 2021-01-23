    public class WebSocketsServer
    {
        #region Fields
        private static CancellationTokenSource m_cancellation;
        private static HttpListener m_listener;
        #endregion
        #region Private Methods
        private static async Task AcceptWebSocketClientsAsync(HttpListener server, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var hc = await server.GetContextAsync();
                if (!hc.Request.IsWebSocketRequest)
                {
                    hc.Response.StatusCode = 400;
                    hc.Response.Close();
                    return;
                }
                try
                {
                    var ws = await hc.AcceptWebSocketAsync(null).ConfigureAwait(false);
                    if (ws != null)
                    {
                        Task.Run(() => HandleConnectionAsync(ws.WebSocket, token));
                    }
                }
                catch (Exception aex)
                {
                    // Log error here
                }
            }
        }
        private static async Task HandleConnectionAsync(WebSocket ws, CancellationToken cancellation)
        {
            try
            {
                    while (ws.State == WebSocketState.Open && !cancellation.IsCancellationRequested)
                    {
                        String messageString = await ReadString(ws).ConfigureAwait(false);
                        var strReply = "OK"; // Process messageString and get your reply here;
                        var buffer = Encoding.UTF8.GetBytes(strReply);
                        var segment = new ArraySegment<byte>(buffer);
                        await ws.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None).ConfigureAwait(false);
                    }
                    await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Done", CancellationToken.None);
            }
            catch (Exception aex)
            {
                // Log error
                try
                {
                    await ws.CloseAsync(WebSocketCloseStatus.InternalServerError, "Done", CancellationToken.None).ConfigureAwait(false);
                }
                catch
                {
                    // Do nothing
                }
            }
            finally
            {
                ws.Dispose();
            }
        }
        private static async Task<String> ReadString(WebSocket ws)
        {
            ArraySegment<Byte> buffer = new ArraySegment<byte>(new Byte[8192]);
            WebSocketReceiveResult result = null;
            using (var ms = new MemoryStream())
            {
                do
                {
                    result = await ws.ReceiveAsync(buffer, CancellationToken.None);
                    ms.Write(buffer.Array, buffer.Offset, result.Count);
                }
                while (!result.EndOfMessage);
                ms.Seek(0, SeekOrigin.Begin);
                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        #endregion
        #region Public Methods
        public static void Start(string uri)
        {
            m_listener = new HttpListener();
            m_listener.Prefixes.Add(uri);
            m_listener.Start();
            m_cancellation = new CancellationTokenSource();
            Task.Run(() => AcceptWebSocketClientsAsync(m_listener, m_cancellation.Token));
        }
        public static void Stop()
        {
            if(m_listener != null && m_cancellation != null)
            {
                try
                {
                    m_cancellation.Cancel();
                    m_listener.Stop();
                    m_listener = null;
                    m_cancellation = null;
                }
                catch
                {
                    // Log error
                }
            }
        }
        #endregion
    }  
