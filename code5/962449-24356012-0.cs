    public static Rectangle HitBox;
    //other fields and methods
    public override void LoadContent(){
        ContentManager content = MyGame.ContentManager;
        Tex = content.Load<Texture2D>("mytexture"); 
        //...
        
        base.LoadContent();      
        this.InitializeAfterLoadingContent();
    }
    private void InitializeAfterLoadingContent(){
        Hitbox = new Rectangle(Pos.X, Pos.Y, Tex.Width, Tex.Height);
    }
