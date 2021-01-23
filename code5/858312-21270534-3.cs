    static void Transport_SIPTransportRequestReceived(SIPEndPoint localSIPEndPoint, SIPEndPoint remoteEndPoint, SIPRequest sipRequest)
    {
        SIPResponse response = SIPTransport.GetResponse(sipRequest, SIPResponseStatusCodesEnum.Ok, null);
        _sipTransport.SendResponse(response);
    }
