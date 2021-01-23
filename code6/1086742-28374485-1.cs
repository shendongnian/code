    internal static void InfoLogWriter(Object threadContext)
    {
        mLog.Info("InfoLogWriterthread started");
        int id = Process.GetCurrentProcess().Id; // make this instance unique
        var serverPipe = new NamedPipeServerStream("consoleRedirect" + id, PipeDirection.In, 1);
        NamedPipeClientStream clientPipe = new NamedPipeClientStream(".", "consoleRedirect" + id, PipeDirection.Out, PipeOptions.WriteThrough);
        mLog.Info("Connecting Client Pipe.");
        clientPipe.Connect();
        mLog.Info("Connected Client Pipe, redirecting stdout");
        HandleRef hr11 = new HandleRef(clientPipe, clientPipe.SafePipeHandle.DangerousGetHandle());
        SetStdHandle(-11, hr11.Handle); // redirect stdout to my pipe
        mLog.Info("Redirection of stdout complete.");
        mLog.Info("Waiting for console connection");
        serverPipe.WaitForConnection(); //blocking
        mLog.Info("Console connection made.");
        using (var stm = new StreamReader(serverPipe))
        {
            while (serverPipe.IsConnected)
            {
                try
                {
                    string txt = stm.ReadLine();
                    if (!string.IsNullOrEmpty(txt))
                        mLog.InfoFormat("DLL MESSAGE : {0}", txt);
                }
                catch (IOException)
                {
                    break; // normal disconnect
                }
            }
        }
        mLog.Info("Console connection broken.   Thread Stopping.");
    }
