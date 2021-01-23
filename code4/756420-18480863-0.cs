    Texture2D sprite = Content.Load<Texture2D>(.....);
    int width = sprite.Width;
    int height = sprite.Height;
    Rectangle sourceRectangle = new Rectangle(int.Max, int.Max, 0, 0);
    Color[] data = new Color[width*height];
    sprite.GetData<Color>(data);
    int maxX = 0;
    int maxY = 0;
    
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {    
            int index = width * y + x;
        
            if (data[index] != Color.Magenta)
            {
            
                if (x < sourceRectangle.X)
                    sourceRectangle.X = x;
                else if (x > maxX)
                    maxX = x;
                
                if (y < sourceRectangle.Y)
                    sourceRectangle.Y = y;
                else if (y > maxY)
                    maxY = y;        
            }
        }
    }
    
    sourceRectangle.Width = maxX - sourceRectangle.X;
    sourceRectangle.Height = maxY - sourceRectange.Y;
