    public class Machine
    {
    	public Action<Event> EventAdded;
    	
        private void Schedule_Event()
        {
            if(EventAdded != null)
    			EventAdded(new Event());
        }
    }
