        Board b;
        int N, M; // dimensions
        int timer;
        int[,] mark; // assign each group of stones a different number
        int[,] mov = // constant to look around
        {
            { -1, -1 }, { -1, 0 }, { -1, +1 },
            { 0, -1 }, { 0, 0 }, { 0, +1 },
            { +1, -1 }, { +1, 0 }, { +1, +1 },
        };
        // Checks for a group of stones surrounded by enemy stones
        // Returns the first group found or null if there is no such group.
        public List<Point> CheckForSurrounded()
        {
            mark = new int[N,M];
    
            for (int i = 0; i < b.SizeX; ++i)
                for (int j = 0; j < b.SizeX; ++j)
                    if (mark[i, j] == 0) // not visited
                    {                        
                        var l = Fill(i, j);
                        if (l != null)
                            return l;
                    }
            return null;
        }
        // Marks all neighboring stones of the same player in cell [x,y]
        // Returns the list of stones if they are surrounded
        private List<Point> Fill(int x, int y)
        {
            int head = 0;
            int tail = 0;
            var L = new List<Point>();
 
            mark[x, y] = ++timer;
            L.Add(new Point(x,y));
            while (head < tail)
            {
                x = L[head].X;
                y = L[head].Y;
                ++head;
                for (int k = 0; k < 8; ++k)
                {
                    // new coords
                    int xx = x + mov[k,0];
                    int yy = y + mov[k,1];
                    if (xx >= 0 && xx < N && yy >= 0 && yy < M) // inside board
                    {
                        if (mark[xx, yy] == 0) // not visited
                        {
                            if (b[xx, yy].IsEmpty) // if empty square => not surrounded
                                return null;
                            if (b[xx, yy].IsMine)
                            {
                                L.Add(new Point(xx,yy)); // add to queue
                                mark[xx, yy] = timer; // visited
                                ++tail;
                            }
                        }
                    }
                }
            }
            // the group is surrouneded
            return L;
        }
