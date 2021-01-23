      public void lightUp(int pos)
    {
        int loopcounter = -2;
        int jcount = 8;
        int stepcount=1;
        int stepcountReflected=0;
        try
        {
            for (int x = 1; x > -6; x--)
                {
                    if (x == 1)
                    {
                        stepcountReflected=0.5*stepcount;
                    }
                    else
                    {
                        stepcountReflected = stepcount;
                    }
                    for (int i = stepcount; i > loopcounter; i =- (2 * stepcountReflected))
                    {
                        int lolPos = pos + (i * columns);
                        for (int j = 0; j < jcount; j++)
                        {
                            tiles[lolPos + j].isVisible = true;
                            tiles[lolPos - j].isVisible = true;
              
                        }
                    }
                    loopcounter = loopcounter - 1;
                    jcount = jcount - 1;
                }
        }
      
        catch (Exception ex)
        {
            // do what yo need to do here
        }
    }
