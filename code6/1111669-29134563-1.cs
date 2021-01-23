    class Tunes
    {
    	private List<Tune> tunes = new List<Tunes>();
    
    	public Tunes()
    	{
    		// Load the data
    	}
    
    	public void GetByBand(string bandName)
    	{
    		return tunes.Where(t => t.Band == bandName)
    	}
    }
