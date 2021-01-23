    class AssetManager
    {
    	private ContentManager content;
    	private Dictionary<string, Texture2D> textures; // fonts, sprites, models and so on
    	
    	AssetManager(ContentManager  pContent)
    	{
    		this.content = pContent;
    		this.textures = new Dictionary<string, Texture2D>();
    	}
    	
    	public void LoadTexture(string pName, string pAssetName)
    	{
    		this.textures.Add(pName, this.content.Load<Texture2D>(pAssetName);
    	}
    	public Texture2D GetTexture(stirng pName)
    	{
    		return this.Textures.ContainsKey(pName) ? this.Textures[pName] : null;
    	}
    }
