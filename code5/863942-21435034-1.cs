    public delegate void IjmFinishedEventHandler(object sender, EventArgs e);
     public event IjmFinishedEventHandler IjmFinished;
    
       protected virtual void OnIjmFinished(EventArgs e)
       {
          if (IjmFinished != null)
                    IjmFinished(this, e);          
       }
