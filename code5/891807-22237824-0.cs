    using QBFC7Lib;
    QBSessionManager sessionMgr = new QBSessionManager();
    sessionMgr.OpenConnection2("AppID", "AppName", ENConnectionType.ctLocalQBD);
    sessionMgr.BeginSession("", ENOpenMode.omDontCare);
    
    IMsgSetRequest msgset = sessionMgr.CreateMsgSetRequest("US", 9, 0);
    
    msgset.ClearRequests();
    msgset.Attributes.OnError = ENRqOnError.roeContinue;
    
    ICustomerQuery query = msgset.AppendCustomerQueryRq();
    query.metaData.SetValue(ENmetaData.mdMetaDataOnly);
    
    IMsgSetResponse msgResp = sessionMgr.DoRequests(msgset);
    
    for(int index=0;index<msgResp.ResponseList.Count;index++)
    {
        IResponse resp = msgResp.ResponseList.GetAt(index);
    
        int count = resp.retCount;
    }
