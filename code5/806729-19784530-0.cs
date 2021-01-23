    int[,] theArray = new int[4,4]{{1,2,3,4},{1,2,3,4},{1,2,3,4},{1,2,3,4}};
    bool above = true;
    bool below = true;
    bool left = true;
    bool right = true;
    for (int i = 0; i < theArray.GetLength(0); i++)
    {
        for (int j = 0; j < theArray.GetLength(1); j++)
        {
            above = true; below = true; left = true; right = true;
            if (i == 0)
            {
                above = false;
            }
            if (i == theArray.GetLength(0) - 1)
            {
                below = false;
            }
            if (j == 0)
            {
                left = false;
            }
            if (j == theArray.GetLength(1) - 1)
            {
                right = false;
            }
            if (above)
            {
                if (left)
                {
                    CheckField(i - 1, j - 1, theArray);
                }
                CheckField(i - 1, j, theArray);
                if (right)
                {
                     CheckField(i - 1, j + 1, theArray);
                }
            }
            if (left)
            {
                CheckField(i, j - 1, theArray);
            }
            if (right)
            {
                CheckField(i, j + 1, theArray);
            }
            if (below)
            {
                if (left)
                {
                    CheckField(i + 1, j - 1, theArray);
                }
                CheckField(i + 1, j, theArray);
                if (right)
                {
                    CheckField(i + 1, j + 1, theArray);
                }
            }
        }
    }
 
    public void CheckField(int i, int j, int[,] theArray)
    {
        // do your stuff...
    }
