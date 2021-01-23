    private void traverseBmp(Action<int, int> doIt)
        {
            for (int x = 0; x < GridSize.X; x++) //For every value in the height of the grid
            {
                for (int y = 0; y < GridSize.Y; y++)//and every value in the width of the grid
                {
                    doIt(x, y);
                }
            }
    
        private void DrawSim() //Creates the bitmap of the grid which is dispalyed on the screen and scales it up
        {
            Bitmap bmp = new Bitmap(GridSize.X, GridSize.Y); //Creates the bitmap specifying the width and height of it
            //These two for loops loop through every part of the grid:
            traverseBmp((x, y) =>
                {
                    Color Colour = Color.Black;
                        //Creates a new color used to set the pixel colour on the bitmap (Empty space is black)
    
                    foreach (Entity e in Entity.GetEntitiesAt(x, y)) //For every entity a the current location...
                    {
                        if ((e as Food) != null) //If it is Food, set the colour to green
                            Colour = Color.FromArgb(Colour.R, 255, Colour.B);
                        else if ((e as Mitosis) != null) //If it is bacteria Mitosis, set the colour to blue
                            Colour = Color.FromArgb(Colour.R, Colour.G, 255);
                        else if ((e as Meiosis) != null) //If it is bacteria Meiosis, set the colour to gold
                            Colour = Color.Gold;
                        else //If it's none of these, the only entity left is the Virus, set the colour to red
                            Colour = Color.FromArgb(255, Colour.G, Colour.B);
                    }
    
                    if (AStar.Grid[x, y].IsWall) //If that location is a wall, set the colour to white
                        Colour = Color.White;
    
                    bmp.SetPixel(x, y, Colour); //Set the pixel at position x and y to the colour chosen above
                });
    
            //Scales up the bitmap into a new bitmap
            Bitmap bmpscale = new Bitmap(GridSize.X * ImageScale, GridSize.Y * ImageScale);
            traverseBmp((x,y) =>
                {
                    for (int sx = 0; sx < ImageScale; sx++)
                    {
                        for (int sy = 0; sy < ImageScale; sy++)
                        {
                            bmpscale.SetPixel(((x*ImageScale) + sx), ((y*ImageScale) + sy), bmp.GetPixel(x, y));
                        }
                    }
                });
    
            this.CreateGraphics().DrawImage(bmpscale, new Point(10, 10)); //Draws the bitmap image at set co-ordinates on the form
        }
