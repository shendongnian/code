    public void PaintHatchBrush(Bitmap input, HatchBrush brush){
       using(Graphics g = Graphics.FromImage(input)){
          g.Clip = GetForegroundRegion(input, Color.Black);
          GraphicsUnit gu = GraphicsUnit.Pixel;
          g.FillRectangle(brush, input.GetBounds(ref gu));
       }
    }
    //This is implemented using `GetPixel` which is not fast, but it gives you the idea.
    public Region GetForegroundRegion(Bitmap input, Color backColor){
      GraphicsPath gp = new GraphicsPath();
          Rectangle rect = Rectangle.Empty;          
          bool jumpedIn = false;
          for (int i = 0; i < bm.Height; i++) {
              for (int j = 0; j < bm.Width; j++) {
                 Color c = bm.GetPixel(j, i);
                 if (c != backColor&&!jumpedIn) {
                     rect = new Rectangle(j, i, 1, 1);                        
                     jumpedIn = true;
                 }
                 if (jumpedIn && (c == backColor || j == bm.Width - 1)) {
                     rect.Width = j - rect.Left;
                     gp.AddRectangle(rect);
                     jumpedIn = false;
                 }
              }
          }
          return new Region(gp);
    }
    //Usage
    HatchBrush brush = new HatchBrush(HatchStyle.Percent30, Color.Green, Color.Yellow);
    PaintHatchBrush(yourImage, brush);
    //then yourImage will have HatchBrush painted on the surface leaving the Black background intact.
    //This image will be used in the next process to turn the Black background into 70%
    //opacity background as you did using ColorMatrix (or more simply using ColorMap as I posted previously)
