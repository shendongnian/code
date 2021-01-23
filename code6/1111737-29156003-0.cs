    public class RockBand : Band
    {
    	private Musician vocalist;
    	private Musician bass;
    	private Musician drums;
    	private Musician guitar;
    
    	public RockBand (string[] lineAra) 
    		: base(lineAra)
    	{
    		if (lineAra.Length >= 3)
    			vocalist = new Musician(lineAra[2], "Vocals");
    
    		if (lineAra.Length >= 4)
    			bass = new Musician(lineAra[3], "bass");
    
    		if (lineAra.Length >= 5)
    			drums = new Musician(lineAra[4], "Drums");
    
    		if (lineAra.Length >= 6)
    			guitar = new Musician(lineAra[5], "Guitar");
    	}
    } 
