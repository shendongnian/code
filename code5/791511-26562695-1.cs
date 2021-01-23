    while (listen) // <--- boolean flag to exit loop
    {
       if (listener.Pending())
       {
          Thread tmp_thread = new Thread(new ThreadStart(() =>
          {
             string msg = null;
              
             clt = listener.AcceptTcpClient();
             using (NetworkStream ns = clt.GetStream())
             using (StreamReader sr = new StreamReader(ns))
             {
                msg = sr.ReadToEnd();
             }
             Console.WriteLine("Received new message (" + msg.Length + " bytes):\n" + msg);
          }
          tmp_thread.Start();
       }
       else
       {
           Thread.Sleep(100); //<--- timeout
       }
    }
