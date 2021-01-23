    public static bool[][] ZhangSuenThinning(bool[][] s)
        {
            bool[][] temp = s;
            bool even = true;
            for (int a = 1; a < s.Length-1; a++)
            {
                for (int b = 1; b < s[0].Length-1; b++)
                {
                    if (SuenThinningAlg(a, b, temp, even))
                    {
                        temp[a][b] = false;
                    }
                    even = !even;
                }
            }
            return temp;
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
                if (bp1 >= 2 && bp1 <= 6)//2nd condition
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
        static int NumberOfZeroToOneTransitionFromP9(int x, int y, bool[][]s)
        {
            bool p2 = s[x][y - 1];
            bool p3 = s[x + 1][y - 1];
            bool p4 = s[x + 1][y];
            bool p5 = s[x + 1][y + 1];
            bool p6 = s[x][y + 1];
            bool p7 = s[x - 1][y + 1];
            bool p8 = s[x - 1][y];
            bool p9 = s[x - 1][y - 1];
            int A = Convert.ToInt32((p2 == false && p3 == true)) + Convert.ToInt32((p3 == false && p4 == true)) +
                     Convert.ToInt32((p4 == false && p5 == true)) + Convert.ToInt32((p5 == false && p6 == true)) +
                     Convert.ToInt32((p6 == false && p7 == true)) + Convert.ToInt32((p7 == false && p8 == true)) +
                     Convert.ToInt32((p8 == false && p9 == true)) + Convert.ToInt32((p9 == false && p2 == true));
            return A;
        }
        static int NumberOfNonZeroNeighbors(int x, int y, bool[][]s)
        {
            int count = 0;
            if (s[x-1][y])
                count++;
            if (s[x-1][y+1])
                count++;
            if (s[x-1][y-1])
                count++;
            if (s[x][y+1])
                count++;
            if (s[x][y-1])
                count++;
            if (s[x+1][y])
                count++;
            if (s[x+1][y+1])
                count++;
            if (s[x+1][y-1])
                count++;
            return count;
        }
