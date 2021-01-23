    class ProjectileManager
    {
    //Lists
    List<Projectile> projectiles = new List<Projectile>();
    //Sprites
    Texture2D sprite;
    Texture2D spriteLaser;
    //Attributes
    Vector2 position;
    Vector2 dimensions;
    int attackPower;
    int moveType; //0 = direction based, 1 = homing on player, 3 = hybrid of both (like a missile that fires straight then turns towards target
    int team; //the team that the laser is on for collision
    Vector2 direction;
    float speed;
    public ProjectileManager(){}
    public void Update()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.E))
        {
            ShootLaser(new Vector2(5,5), 5, 1, new Vector2(0,0), 0, 0);
        }
        foreach (Projectile each in projectiles)
        {
            each.Update();
        }
    }
    public void ContentLoad(ContentManager content)
    {
        spriteLaser = content.Load<Texture2D>("playerLaser");
    }
    public void Draw(SpriteBatch spritebatch)
    {
        spritebatch.Begin();
        foreach (Projectile p each in projectiles)
        {
            spritebatch.draw(spriteLaser, p.position,Color.CoolColor);//see how I use the projectile info (p.position).  it doesn't need it's own texture :)
        }
        
        spritebatch.End();
    }
