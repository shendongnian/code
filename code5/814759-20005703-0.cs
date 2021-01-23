    private void SqlAStart()
    {
        ServerThread = new Thread(HttpSrv.listen);
        ServerThread.Start();
        ...
        this.Dispatcher.Invoke((Action)(() => {
            WorkingBar.Value = ...                
        }));
        ....
    }
