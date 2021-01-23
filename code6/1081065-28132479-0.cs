    Socket newSocket = socket.Accept()
    try
    {
        using (newSocket) //when it's done, will automatically dispose the socket.
        {
    	    ConnectionClient conn = new ConnectionClient(newSocket, ShowMsg, RemoveClientConnection, SendMsgToController);
    	    string strRemoteEndPoint = newSocket.RemoteEndPoint.ToString();
    	    if (dictConn.ContainsKey(strRemoteEndPoint.Substring(0, strRemoteEndPoint.LastIndexOf(":"))))
    	        dictConn[strRemoteEndPoint.Substring(0, strRemoteEndPoint.LastIndexOf(":"))].isRec = true;
    	    else
    	        dictConn.Add(strRemoteEndPoint.Substring(0, strRemoteEndPoint.LastIndexOf(":")), conn);
    	    UpdateControllerStatus(strRemoteEndPoint, " online");
        }
    }
    catch (Exception ex)
    {
    	socket.Close(); //if something bad happens, close the socket automatically and release the resources
        ExceptionLog(ex);
    }
