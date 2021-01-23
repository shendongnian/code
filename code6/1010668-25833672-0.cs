    IEnumerable AttemptHeadsetConnection(int portNumber,Action<int,int> headsetConnectedCallback, Action attemptCompletedCallback)
    {
        var connectionString = string.Format("\\\\.\\COM{0}",portNumber);//That string literal should be elsewhere
        return AttemptHeadsetConnection(connectionString, headsetConnectedCallback, attemptCompletedCallback);
    }
    IEnumerable AttemptHeadsetConnection(string connectionString,Action<int,int> headsetConnectedCallback,Action attemptCompletedCallback)
    {
        connectionID = ThinkGear.TG_GetNewConnectionId();
        connectionStatus = ThinkGear.TG_Connect(connectionID ,
                                              connectionString,
                                              ThinkGear.BAUD_9600,
                                              ThinkGear.STREAM_PACKETS);
        if(connectStatus >= 0)
        {
           yield return new WaitForSeconds(2f); //Give the headset at least 2 seconds to respond with valid data
           int receivedPackets = ThinkGear.TG_ReadPackets(handleID, -1);//Read all the packets with -1
           if(receivedPackets > 0)
           {
               headsetConnectedCallback(connectionID,connectionStatus);
           } 
           else 
           {
              ThinkGear.TG_FreeConnection(handleID);              
           }
           
       }
       attemptCompletedCallback();
    }
