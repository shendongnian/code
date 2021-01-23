    public class RockBand : Band
    {
    	public RockBand(string[] lineAra, Musician vocalist, Musician bass, Musician drums, Musician guitar)
    		: base(lineAra)
    	{
    		Vocalist = vocalist;
    		BassPlayer = bass;
    		Drummer = drums;
    		GuitarPlayer = guitar;
    	}
    
    	public Musician Vocalist { get; set; }
    
    	private Musician BassPlayer { get; set; }
    
    	private Musician Drummer { get; set; }
    
    	private Musician GuitarPlayer { get; set; }
    }
