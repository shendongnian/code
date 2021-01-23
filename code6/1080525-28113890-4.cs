    class Level {
       public Texture2D Texture {
          get {
             if( IsLocked )
                return lockedTexture;
    
             return unlockedTexture;
          }   
       }
    
       public bool IsLocked = true;
       private Texture2D lockedTexture, unlockedTexture;
    
       public LoadContent( ContentManager content, string lockedPath, string unlockedPath ){
           lockedTexture = content.Load<Texture2D>( lockedPath );
           unlockedTexture = content.Load<Texture2D>( unlockedPath );
       }
    }
