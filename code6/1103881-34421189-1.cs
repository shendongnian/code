    public void Execute(Action<T> action)
    {
        T proxy = CreateChannel();
    
        action(proxy);
    
        ((ICommunicationObject)proxy).Close();
    }
