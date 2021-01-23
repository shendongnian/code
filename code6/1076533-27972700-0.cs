    public abstract class IconPresentation{}
    public sealed class ImageIconPresentation
    {
    	private readonly string _url;
    
    	public Uri IconSource
    	{
    		get { return new Uri(_url); }
    	}
    
    	public ImageIconPresentation(string url){
    		_url = url;
    	}
    }
    
    public sealed class ResourceIconPresentation
    {
    	public string Name
    	{
    		get;
    		private set;
    	}
    
    	public ResourceIconPresentation(string name){
    		Name = name;
    	}
    }
