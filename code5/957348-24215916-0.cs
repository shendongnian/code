    public class NhunspellHelper
    {
    	private readonly Hunspell _hunspell;
    	private NhunspellHelper()
    	{
    		_hunspell = new Hunspell(
    						HttpContext.Current.Server.MapPath("~/App_Data/en_US.aff"),
    						HttpContext.Current.Server.MapPath("~/App_Data/en_US.dic"));
    	}
    
    	private static NhunspellHelper _instance;
    	public static NhunspellHelper Instance
    	{
    		get { return _instance ?? (_instance = new NhunspellHelper()); }
    	}
    	
    	public bool Spell(string word)
    	{
    		return _hunspell.Spell(word);
    	}
    }
