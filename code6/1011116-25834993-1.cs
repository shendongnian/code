    MyElement[,] tiles = new MyElement[8, 8];
    for(int i = 0; i < 8; i++)
    {
        for(j = 0; j < 8; j++)
        {
            tiles[i, j] = new MyElement { IsPressed = false; Uri = whatever; ... };
        }
    }
