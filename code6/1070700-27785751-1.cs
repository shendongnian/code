    public void NotifyEntityUpdated(int userId, int entityId)
    {
       Action currentAction = () =>
       {
          EntityUpdatedByUser(userId, entityId);
       };
       this.Dispatcher.Invoke(currentAction,  DispatcherPriority.Send);
    
      Action currentAction2 = () =>
       {
          SendEmail(userId, entityId);
       };
       this.Dispatcher.BeginInvoke(currentAction2, DispatcherPriority.Loaded);
    }
