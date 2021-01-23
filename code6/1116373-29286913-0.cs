    public class MyClass
    {
      private Rectangle _MyBox; // or protected idk.
      // This is public and read only.
      public Rectangle MyBox { get { return _MyBox; } }
     
      public UpdateBox(int x, int y)
      {
        _MyBox.X = x;
        _MyBox.Y = y;
      }
    }
