    public class CArtist : IArtist
    {
    	[ImportingConstructor]
    	public CArtist(IArtistRepository repository)
    	{
    		this.repository = repository;
    	}
    	
    	public void Load(Guid guid)
    	{
    		this.SomeArtist.DoSomething(guid);
    		...
    	}
    	
    	[Import(typeof(IArtist))]
    	private IArtist SomeArtist { get; set; }
    }
