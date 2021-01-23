    public event EventHandler<EventArgs> ReservationComplete;
 
    protected virtual void OnReservationComplete()
    {
        EventHandler<EventArgs> handler = this.ReservationComplete;
        if (handler != null)
        {
            handler(this, EventArgs.Empty);
        }
    }
...
      if (DBReserveer.QueryStatus == true)
      {
         MessageBox.Show("Het item is gereserveerd!");
         this.OnReservationComplete();
          // Event should be raised from here
      }
