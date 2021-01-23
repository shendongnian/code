    public static class NewDataManager
    {
        public static ISoccer SoccerInstance { get; private set; }
    
        static NewDataManager()
        {
             SoccerInstance =  new Soccer();
        }
    	
    	private class Soccer : ISoccer
    	{
    		
        	public Soccer()
        	{
        	}
    	}
    }
    
    public interface ISoccer {}
