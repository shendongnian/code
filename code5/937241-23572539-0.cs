    public event OnWorkCompleted;
    public void WorkComplete()
    {
       if(OnWorkCompleted != null)
           OnWorkCompleted(Property, null);
    }
