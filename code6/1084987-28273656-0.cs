    public async Task handleClientConnection(HttpListener listener){
        HttpListenerContext context = await listener.GetContextAsync(res);
        var ret = handleClientConnection(listener);
        HttpListenerRequest request = context.Request;
        // Obtain a response object.
        HttpListenerResponse response = context.Response;
        // Construct a response. 
        // add a delay to simulate data process
        String before_wait = String.Format("{0}", DateTime.Now);
        await Task.Wait(4000);
        String after_wait = String.Format("{0}", DateTime.Now);
        string responseString = "<HTML><BODY> BW: " + before_wait + "<br />AW:" + after_wait + "</BODY></HTML>";
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
        // Get a response stream and write the response to it.
        response.ContentLength64 = buffer.Length;
        using(System.IO.Stream output = response.OutputStream)
            output.Write(buffer, 0, buffer.Length);
        await ret;
    }
    public void startServer(){
        HttpListener HL = new HttpListener();
        HL.Prefixes.Add("http://127.0.0.1:800/");
        HL.Start();
        await handleClientConnection(HL);
    }
