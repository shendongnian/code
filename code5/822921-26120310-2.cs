    public static bool[][] ZhangSuenThinning(bool[][] s)
    {
        bool[][] temp = ArrayClone(s);  // make a deep copy to start.. 
        int count = 0;
        do  // the missing iteration
        {
            count  = step(1, temp, s);
            temp = ArrayClone(s);      // ..and on each..
            count += step(2, temp, s);
            temp = ArrayClone(s);      // ..call!
        }
        while (count > 0);
        return s;
    }
    static int step(int stepNo, bool[][] temp, bool[][] s)
    {
        int count = 0;
        for (int a = 1; a < temp.Length - 1; a++)
        {
            for (int b = 1; b < temp[0].Length - 1; b++)
            {
                if (SuenThinningAlg(a, b, temp, stepNo == 2))
                {
                    // still changes happening?
                    if (s[a][b]) count++; 
                    s[a][b] = false; 
                }
            }
        }
        return count;
    }
    static bool SuenThinningAlg(int x, int y, bool[][] s, bool even)
    {
        bool p2 = s[x][y - 1];
        bool p3 = s[x + 1][y - 1];
        bool p4 = s[x + 1][y];
        bool p5 = s[x + 1][y + 1];
        bool p6 = s[x][y + 1];
        bool p7 = s[x - 1][y + 1];
        bool p8 = s[x - 1][y];
        bool p9 = s[x - 1][y - 1];
        int bp1 = NumberOfNonZeroNeighbors(x, y, s);
        if (bp1 >= 2 && bp1 <= 6) //2nd condition
        {
            if (NumberOfZeroToOneTransitionFromP9(x, y, s) == 1)
            {
                if (even)
                {
                    if (!((p2 && p4) && p8))
                    {
                        if (!((p2 && p6) && p8))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (!((p2 && p4) && p6))
                    {
                        if (!((p4 && p6) && p8))
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
    static int NumberOfZeroToOneTransitionFromP9(int x, int y, bool[][] s)
    {
        bool p2 = s[x][y - 1];
        bool p3 = s[x + 1][y - 1];
        bool p4 = s[x + 1][y];
        bool p5 = s[x + 1][y + 1];
        bool p6 = s[x][y + 1];
        bool p7 = s[x - 1][y + 1];
        bool p8 = s[x - 1][y];
        bool p9 = s[x - 1][y - 1];
        int A = Convert.ToInt32((!p2  && p3 )) + Convert.ToInt32((!p3  && p4 )) +
                Convert.ToInt32((!p4  && p5 )) + Convert.ToInt32((!p5  && p6 )) +
                Convert.ToInt32((!p6  && p7 )) + Convert.ToInt32((!p7  && p8 )) +
                Convert.ToInt32((!p8  && p9 )) + Convert.ToInt32((!p9  && p2 ));
        return A;
    }
    static int NumberOfNonZeroNeighbors(int x, int y, bool[][] s)
    {
        int count = 0;
        if (s[x - 1][y])     count++;
        if (s[x - 1][y + 1]) count++;
        if (s[x - 1][y - 1]) count++;
        if (s[x][y + 1])     count++;
        if (s[x][y - 1])     count++;
        if (s[x + 1][y])     count++;
        if (s[x + 1][y + 1]) count++;
        if (s[x + 1][y - 1]) count++;
        return count;
    }
