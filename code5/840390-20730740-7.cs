    public event EventHandler<EventArgs> ReservationComplete;
 
    protected virtual void OnReservationComplete()
    {
        EventHandler<EventArgs> handler = this.ReservationComplete;
        if (handler != null)
        {
            handler(this, EventArgs.Empty);
        }
    }
