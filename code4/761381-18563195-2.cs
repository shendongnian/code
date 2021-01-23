    public void AcknowledgeComplete(CollectionTask task)
    {
        if (task.Timeout < DateTime.Now)
             AcknowledgeError(task, new Exception());
        ....
        ....
    }
