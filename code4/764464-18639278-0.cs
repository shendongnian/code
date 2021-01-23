    task.Add(Task.Factory.StartNew(() =>  Process(tp)));
    void Process(TaskPlanner tp)
    {
        try
        {
            tp.ExecuteBot.Execute();
        }
        catch (WebException wex)
        {
        }
    }
