    public void loadtemplist(DataTable dt)
    {
      this.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle,
          new Action(() => { this.loadtemplist1(dt); } )
          );
    }
