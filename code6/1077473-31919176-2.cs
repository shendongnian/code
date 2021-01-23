    private async void OnButton1_clicked(object sender, ...)
    {
        var Tasks = new List<Task>();
        for (int i=0; i<10; ++i)
        {
            Tasks.Add(Run());
        }
        // while all tasks are scheduled to run, do other things
        // after a while you need the result:
        await Task.WhenAll(tasks);
        // Task.WhenAll(...) returns a Task, so await Task.WhenAll returns void
        // async functions that return Task`<TResult`> has a Result property 
        // that has the TResult value when the task if finished:
        foreach (var task in tasks)
        {
            ProcessResult(task.Result);
        }
        // not valid for your Run(), because that had a Task return value.
    }
