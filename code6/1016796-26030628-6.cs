    class Player
    {   
    // Inherent classes
    ProjectileManager projectileManager = new ProjectileManager();
    Texture2D sprite;
    public Vector2 direction;
    float speed;
    float health;
    int spriteType;
    public void LoadContent(CoolContentType coolContent)
    {
        projectileManager.LoadContent(coolContent);
    }
    public void Update()
    {
        UpdateControls();
    }
