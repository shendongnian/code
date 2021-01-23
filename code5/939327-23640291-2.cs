    void MainMethod()
    {
        bool success = true;
        Thread connectThread = new Thread(() => {
            success = TryConnectingToAnalysisServer(connectionString); 
        });
    }
    
