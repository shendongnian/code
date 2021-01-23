    public class TickHandlerObject{
    	// This class subscribes to the Updated event of myTicker.
    	private Ticker myTicker;
        myTicker.Updated += this.TickerUpdated;
    	public bool IsBusy{get;set;}
        private void TickerUpdated()
		{
			// thread-safing
			this.IsBusy = true;
			// do stuff that can take longer than the tick interval
			//  thread-safing
			this.IsBusy = false;
		}
	}
