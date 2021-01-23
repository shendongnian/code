    public void OnClick(object src,EventArgs args)
    {
        var login = tbLogin.Text;// assuming non MVVM coding here
        var pwd= tbPass.Text;
        Task.Factory.StartNew(()=>{
            return _myWebService.CheckAuth(login,pwd); // your login stuff here
        }).ContinueWith(wsTask=>{
           if(!wsTask.IsCompleted){ // handle errors / cancel }
           DisplayLoginState(ws.Result);
        }, TaskScheduler.FromCurrentSynchronizationContext()); // this runs on the UI Thread
    
    }
