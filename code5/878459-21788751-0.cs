    // Check what LastRestartTime is and if it is greater that RestartInterval, kill the process and restart it.
    foreach(RestartData restartData in restartJob)
    {
        if (DateTime.Now > restartData.LastRestartTime.AddHours(-restartData.RestarInterval))
        {
            restartData.LastRestartTime.AddHours(-1);
            // restart process
        }
    }
