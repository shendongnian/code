    using QBFC12Lib;
    private void button1_Click(object sender, EventArgs e)
    {
        // Create a new thread and start it
        Thread backgroundThread = new Thread(new ThreadStart(Method));
        backgroundThread.SetApartmentState(ApartmentState.STA);
        backgroundThread.Start();
    }
    private void Method()
    {
        QBSessionManager sessionMgr = new QBSessionManager();
        sessionMgr.OpenConnection2("AppID", "AppName", ENConnectionType.ctLocalQBD);
        sessionMgr.BeginSession("", ENOpenMode.omDontCare);
        IMsgSetRequest MsgRequest = sessionMgr.CreateMsgSetRequest("US", 12, 0);
        MsgRequest.Attributes.OnError = ENRqOnError.roeContinue;
        ICustomerQuery query = MsgRequest.AppendCustomerQueryRq();
        query.metaData.SetValue(ENmetaData.mdMetaDataOnly);
        IMsgSetResponse MsgResponse = sessionMgr.DoRequests(MsgRequest);
        if (MsgResponse != null && MsgResponse.ResponseList != null)
        {
            IResponse response = MsgResponse.ResponseList.GetAt(0);
            MessageBox.Show(response.retCount.ToString());
        }
    }
