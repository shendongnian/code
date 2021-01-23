     private void StartTask<T>(string parameter)
    {
        dynamic instance = (T) Activator.CreateInstance(typeof(T), parameter);
    
        Task.Factory.StartNew(() => {instance.DoCompare();});
    }
