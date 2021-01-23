    void RunStuff()
    {
        Task.Factory.StartNew(() => Things()).ContinueWith(task =>
        {
            if (task.Result)
            {
                Task.Factory.StartNew(() => MoreThings());
            }
        });
    }
