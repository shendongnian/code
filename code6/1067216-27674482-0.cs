    private Action CreateTaskHandler(int arg1)
    {
        return () => DownloadAudio(music[arg1], lstQueue.Items[arg1])
    }
    
    Task[] downloadTasks = new Task[music.Count];
    for (int i = 0; i < music.Count; i++)
        downloadTasks[i] = Task.Factory.StartNew(CreateTaskHandler(i));
    }
