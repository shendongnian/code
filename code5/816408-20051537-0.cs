    for (int x = 0; x <= xMax; x++)
    {
        if (tile[x]==null)
            continue;
        for (int y = 0; y <= yMax; y++)
        {
            if (tile[x][y]==null)
                continue;
            Rectangle tileRectangle = tile[x][y].Target; //THIS LINE FAILS !!!!
            //Snipped code here
        }
    }
