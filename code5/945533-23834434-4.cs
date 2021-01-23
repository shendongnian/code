    private void Process(object state)
    {
        var task = (Task)state;
        try
        {
            task.Callback();
        }
        catch (Exception e)
        {
            if (task.Error != null)
            {
                task.Error(e);
            }
        }
    }
