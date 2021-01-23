        class Player
        {
           private bool initialized = false;
           public Player()
           {}
    
           public void Init(Texture2D newTexture, Vector2 newPosition, Viewport theViewport, Color newColour)
           {
              //All the stuff your constructor used to do
              initialized = true;
           }
    
           public void SomeFunctionUsingVariables()
           {
           if (initialized)
           { //Do whatever }
           }
        }
