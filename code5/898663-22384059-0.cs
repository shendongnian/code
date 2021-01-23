    public class YellowGuy
    {
       public Point Position {get; set;}
       public Size Size {get; set;}
       public Bitmap YellowGuyImage {get; set;}   
    
       public YellowGuy(Bitmap img, Point startPos, Size desiredSize)
       {
          YellowGuyImage = img;
          Size = desiredSize;
          Position = startPos;
       }
    
       public void Draw(Graphics g)
       {
          g.DrawImage(YellowGuyImage, new rectangle(Position, Size);
       }
    }
