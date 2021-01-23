    Socket currentSocket;
    try
    {
        /* Socket stuff with currentSocket */
    }
    catch (SocketException se)
    {
        if (ex.ErrorCode == (int)SocketError.ConnectionAborted)
        {
                        //Remove socket from list
            ConnectionAborted( currentSocket ); // At his point currentSocket is in scope.
        }
    }
