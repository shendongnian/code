        public class testclass
        {
            public int Checkboard(int[,] b)
            {
                for (int x = 0; x < b.GetLength(0); x++)
                {
                    for (int y = 0; y < b.GetLength(1); y++)
                    {
                        for (int d = 0; d < 3; d++)
                        {
                            int p = b[x, y];
                            if (p != 0)
                            {
                                if (countDir(0, b, x, y, d, p) >= 3)
                                {
                                    //win for p
                                    return p;
                                }
                            }
                        }
                    }
                }
                return -1;
            }
            protected int countDir(int depth, int[,] b, int x, int y, int dir, int p)
            {
                int x2;
                int y2;
                if (getposdir(b, x, y, dir, out x2, out y2) == p)
                {
                    //good
                    depth++;
                    return countDir(depth, b, x2, y2, dir, p);
                }
                else
                {
                    return depth;
                }
            }
            protected int getposdir(int[,] b, int x, int y, int dir, out int x2, out int y2)
            {
                if (dir == 0)
                {
                    x2 = x + 1;
                    y2 = y;
                }
                else if (dir == 1)
                {
                    x2 = x + 1;
                    y2 = y + 1;
                }
                else if (dir == 2)
                {
                    x2 = x;
                    y2 = y + 1;
                }
                else
                {
                    throw new Exception("unknown");
                }
                return getpos(b, x2, y2);
            }
            protected int getpos(int[,] b, int x, int y)
            {
                if (b.GetLength(0) <= x)
                {
                    return -1;
                }
                if (b.GetLength(1) <= y)
                {
                    return -1;
                }
                return b[x, y];
            }
        }
