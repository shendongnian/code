        button1.Enabled = false;
        runningTasks = 2;
        ...
        stlFile.OnReadUpdate += stlFile_OnReadUpdate;
        stlFile2.OnFinished += stlFile_OnFinished;
        stlFile.OnReadUpdate += stlFile_OnReadUpdate;
        stlFile2.OnFinished += stlFile_OnFinished;
        List<Task> taskList = new List<Task>();
        taskList.Add(...);
        taskList.Add(...);
        foreach (Task t in taskList)
            t.Start();
    }
    private void stlFile_OnFinished(object sender, EventArgs e)
    {
        runningTasks--;
        if (runningTasks <= 0)
            this.Invoke(new Action(() => button1.Enabled = true));
    }
