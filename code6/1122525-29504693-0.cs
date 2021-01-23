    class createMap
    {
       
        PictureBox tile = new PictureBox();    
        public PictureBox renderMap()
        {
            int[,] mapArray = new int[10, 10]{
            {2,2,2,2,2,2,2,2,2,2},
            {2,1,1,1,1,1,1,1,1,2},
            {2,1,1,1,1,1,1,1,1,2},
            {2,1,1,1,1,1,1,1,1,2},
            {2,1,1,1,1,1,1,1,1,2},
            {2,1,1,1,1,1,1,1,1,2},
            {2,1,1,1,1,1,1,1,1,2},
            {2,1,1,1,1,1,1,1,1,2},
            {2,1,1,1,1,1,1,1,1,2},
            {2,1,1,1,1,1,1,1,1,2},
        };
            
            MessageBox.Show(mapArray.GetLength(0) + ":" + mapArray.GetLength(1));
            MessageBox.Show(mapArray[1, 1] + ":" + mapArray[2, 2]);
            for (int x = 0; x < mapArray.GetLength(0); x++)
            {
                for (int y = 0; y < mapArray.GetLength(1); y++)
                {
                    Debug.WriteLine("X:" + x + " Y: " + y + " Tile: " + mapArray[x, y]);
                    if (mapArray[x, y] == 1)
                    {
                       // canvas.createTile(0, 0, 1);                        
                        tile.Location = new Point(20, 20);
                        tile.Image = Resources.dirt;
                       // canvas.Controls.Add(tile);
                    }
                    if (mapArray[x, y] == 2)
                    {
                       // canvas.createTile(0, 0, 2);                                     
                        tile.Location = new Point(20, 40);
                        tile.Image = Resources.stone;
                      //  canvas.Controls.Add(tile);
                        
                    }
                    
                   //canvas.Update();
                  
                }
            }
            return tile;
        }
       
    }
