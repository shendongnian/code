    public class Publisher : IEventCaller
    {
        public event MyDel MyDeleteEvent;
    	public void OnDeleteOccured()
    	{
    		var myDeleteEvent = MyDeleteEvent;
    		if (myDeleteEvent != null)
    		{
    			MyDeleteEvent(1);
    		}
    	}
    }
