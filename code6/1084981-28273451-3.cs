    public void clientConnection(IAsyncResult res){
        HttpListener listener = (HttpListener)res.AsyncState;
        HttpListenerContext context = listener.EndGetContext(res);
        //tell listener to get the next context directly.
        listener.BeginGetContext(clientConnection, listener);
        HttpListenerRequest request = context.Request;
        // Obtain a response object.
        HttpListenerResponse response = context.Response;
        // Construct a response. 
        // add a delay to simulate data process
        String before_wait = String.Format("{0}", DateTime.Now);
        Thread.Sleep(4000);
        String after_wait = String.Format("{0}", DateTime.Now);
        string responseString = "<HTML><BODY> BW: " + before_wait + "<br />AW:" + after_wait + "</BODY></HTML>";
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
        // Get a response stream and write the response to it.
        response.ContentLength64 = buffer.Length;
        System.IO.Stream output = response.OutputStream;
        // You must close the output stream.
        output.Write(buffer, 0, buffer.Length);
        output.Close();
    }
