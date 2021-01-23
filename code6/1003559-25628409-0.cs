    AlertMsg alertMsg = new AlertMsg();
    alertMsg.ShowMsg("message 1", "message 1 description", 
        AlertMsg.MsgTypes.Warning);
    
    await Task.Run(() => SomeLongRunningOperation());
    
    alertMsg.ShowMsg("message 2", "message 2 description", 
        AlertMsg.MsgTypes.Critical);
    await Task.Run(() => AnotherLongRunningOperation());
