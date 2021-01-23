    public void OnStatusUpdated(Status newStatus)
    {
         if (InvokeRequired)
         {
             Invoke(delegate
                {
                    statusControl.Text = newStatus.ToString(); // Or something like it.
                });
         }
    }
