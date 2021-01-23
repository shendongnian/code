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
        internal static void RedirectConsole()
        {
            mLog.Info("RedirectConsole called.");
            ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(InfoLogWriter));
            // TODO enqueue and item for error messages too.
        }
I'm having trouble with it disconnecting and have to reconnect the pipes, but I'll figure out a reconnect solution.   I'm guessing that happens when DLLs get swapped back out of memory or perhaps when I need to read but there isn't anything currently ready to be read?  I've also got to setup another pair to snag stderr and redirect it as well, using Error logs for that one.   Probably want to get rid of the magic number (-11) and use the normal enums as well (STD_ERROR_HANDLE, etc)
