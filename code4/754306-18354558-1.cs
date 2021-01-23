    public static void OnClientConnect(IAsyncResult asyn)
                {
                    try
                    {
                        Socket m_socWorkerInstance = m_socListener.EndAccept(asyn);
                        clientSocketList.Add(m_socWorkerInstance);
        
                        WaitForData(m_socWorkerInstance);
                    }
                    catch (ObjectDisposedException)
                    {
                        System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
                    }
                    catch (SocketException se)
                    {
                        Console.WriteLine(se.Message);
                    }
        
                }
        public static void WaitForData(System.Net.Sockets.Socket soc)
                {
                    try
                    {
                        if (pfnWorkerCallBack == null)
                        {
                            pfnWorkerCallBack = new AsyncCallback(OnDataReceived);
                        }
                        CSocketPacket theSocPkt = new CSocketPacket();
                        theSocPkt.thisSocket = soc;
                        // now start to listen for any data...
                        soc.BeginReceive(theSocPkt.dataBuffer, 0, theSocPkt.dataBuffer.Length, SocketFlags.None, pfnWorkerCallBack, theSocPkt);
                        m_socListener.BeginAccept(new AsyncCallback(OnClientConnect), null);
                    }
                    catch (SocketException se)
                    {
                        Console.WriteLine(se.Message);
                    }
        
                }
