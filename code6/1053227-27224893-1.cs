    class Sprite
    {
    	public Texture2D texture;
    	public Rectangle Frame;
    	private frameIndex;
    	private frameCount;
    	private frameDuration;
    	private frameInterval;
    	
    	public Sprite(Texture pTexture, ...)
    	{
    		// init sprite data
    	}
    	public Update(GameTime pGameTime)
    	{
    		// update sprite data
    	}
    }
    
    class Invider
    {
    	private Sprite Sprite;
    	public Vector2 Porision;
    	public int Health;
    	
    	public Invider(Sprite pSprite, Vector2 pPosition)
    	{
    		this.Sprite = pSprite;
    		this.Position = pPosition;
    	}
    	public void Update(GameTime pGameTime)
    	{
    		// update invider data
    	}
    	public void Draw(SpriteBatch pSpriteBatch)
    	{
    		pSpriteBatch.Draw(this.Sprite.Texture, this.Sprite.Frame, this.Position, Color.White);
    	}
    }
    
    public class Game1 : Game
    {
    	private SpriteBatch spriteBatch;
    	private Dictionary<int, Invider> invidersByID;
    	private Sprite inviderSprite;
    	
    	public override Initialize()
    	{
    		// fill inviderByID collection
    	}
    	
    	public override LoadData()
    	{
    		// create inviderSprite
    	}
    	
    	public static UpdateStatic(GameTime pGameTime)
    	{
    		// update static data like frame index
    	}
    	public override void Update(GameTime pGameTime)
    	{
    		this.inviderSprite.Update(pGameTime);
    		
    		foreach(Invider invider in invidersByID.Values){
    		{
    			invider.Update(pGameTime);
    		}
    	}
    	public override Draw(SpriteBatch pSpriteBatch)
    	{
    		this.spriteBatch.Begin();
    		foreach(Invider invider in invidersByID.Values){
    		{
    			invider.Update(pGameTime);
    		}
    		this.spriteBatch.End();
    	}
    }
