    public class Spritesheet
    {
      public Spritesheet(int spritesToIndex)
      {
        if (spritesToIndex < 0 || spritesToIndex > 256)
          throw new ArgumentOutOfRangeException ("spritesToIndex", "Number of sprites must be between 0 and 256 (inclusive)");
        // ...
      }
    }
