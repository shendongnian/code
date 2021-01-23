    public void AddToQueue(Action action)
    {
        if (m_BatchTask == null)
            m_BatchTask = Task.Run(action);            
        else                
            m_BatchTask = AddToQueue(m_BatchTask, action);                        
    }
    public async Task AddToQueue(Task existingTask, Action action)
    {
        await existingTask;
        action();                       
    }
