    public class Spritesheet
    {
      public Spritesheet(int spriteCount)
      {
        if (spriteCount < 0 || spriteCount > 256)
          throw new ArgumentOutOfRangeException ("spriteCount", "Number of sprites must be between 0 and 256 (inclusive)");
        // ...
      }
    }
