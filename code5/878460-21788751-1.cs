    // Check what LastRestartTime is and if it is greater that RestartInterval, kill the process and restart it.
    DateTime dt = DateTime.Now; // Keep DateTime static.
    foreach(RestartData restartData in restartJob)
    {
        if (dt >= restartData.LastRestartTime.AddHours(restartData.RestarInterval))
        {
            restartData.LastRestartTime = dt;
            // restart process
        }
    }
