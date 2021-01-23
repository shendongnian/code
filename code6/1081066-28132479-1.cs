    try
    {
        using (Socket newSocket = socket.Accept()) //when it's done, will automatically dispose the socket.
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
    	ExceptionLog(ex);
    }
