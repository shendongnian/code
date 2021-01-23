    List<Rectangle> rects = new List<Rectangle>();
    void LoadMap()
    {
        Texture2D map = Content.Load<Texture2D>(@"TexturePath");
        //Get a 1D array with image's pixels
        Color[] map_pixels = new Color[map.Width * map.Height];
        map.GetData(map_pixels);
        
        //Convert it in a 2D array
        Color[,] map_pixels_2D = new Color[map.Width, map.Height];
        for (int x = 0; x < map.Width; x++)
           for (int y = 0; y < map.Height; y++)
              map_pixels_2D[x, y] = map_pixels[x + y * map.Width];
       
        //**NOTE THAT**: From here it is just an example, probably not working good,
        //I wrote it just to share the idea
        //Here goes the code to trace rectangles in the map
        Rectangle r = Rectangle.Empty;
        bool NWvertex_done = false, NEvertex_done = false, SWvertex_done = false;
        for (int x = 0; x < map.Width; x++)
        {
           if (!SWvertex_done)
           {
              if (map_pixels_2D[x, y+1] == Color.White); //last bottom vertex
              {
                 r.Height = r.Y + y;
                 SWvertex_done = true;
                 rects.Add(r);
                 NWvertex_done = false;
                 NEvertex_done = false;
                 r = Rectangle.Empty;
              }
           }
           for (int y = 0; y < map.Height; y++)
           {
              if (map_pixels_2D[x, y] != Color.White
              {
                 if (!NWvertex_done)
                 {
                   SWvertex_done = false;
                   r.X = x;
                   r.Y = y;
                   NWvertex_done = true;
                 }
                 else if(!NEvertex_done)
                 {
                   if (map_pixels_2D[x, y+1] == Color.White); //last right vertex
                   {
                     r.Width = r.X + x;
                     NEvertex_done = true;
                   }
                 }
              }
           } 
         }
    }
    public override void Update(GameTime gametime)
    {
         //maybe other things
         //
    
         foreach (Rectangle rect in rects)
         {
            //Better with Distance of ball-center and rect
            if (ballRect.Intersect(rect))
            {
               //there is a collision!
               //Do something
            }
            break;
         }
    
         //maybe other things
         //
    }
