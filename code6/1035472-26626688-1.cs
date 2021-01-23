    //m_RemindersTask is a member of type Task
    if(m_RemindersTask != null && m_RemindersTask.Status != TaskStatus.Running) //prevent simultaneous execution
    {
        m_RemindersTask = Task.Factory.StartNew(() => this.SendReminders());
        logger.Info("Waiting for sending to complete...");
        task.ContiueWith(p => /*work to be done after the task*/, 
        TaskScheduler.FromCurrentSynchronizationContext()); //this [optional parameter] makes sure that the continuation is run on the same thread that the scheduling method is run on, if possible.
    }
    else
        //Is Warning the correct method? You get the idea
        logger.Warning("Cannot send reminders: reminders are already being sent.");
