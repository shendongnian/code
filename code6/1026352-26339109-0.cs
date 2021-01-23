    public Status SendMessage(InParam inParam)
    {
        try
        {
            return AsyncPump.Run(() => MethodAsync(inParam));
        }
        catch (Exception ex)
        {
            // Log the exception
            return Status.Failed;
        }
    }
