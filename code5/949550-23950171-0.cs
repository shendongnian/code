    public interface IPiece : IDisposable
    {
        void Draw(spriteBatch s);
    }
    
    // ...
    
    public void DrawCache(spriteBatch s)
    {
        // On RenderTarget2D cache_
        foreach(var piece in this.pieces)     
        {
          using(piece)
          {
             piece_.Draw(s);
          }
        }
    }
