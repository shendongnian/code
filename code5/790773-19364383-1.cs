    public void checkIfNeighbors(int x, int y)
        {
            bool left = false;
            bool right = false;
            bool up = false;
            bool down = false;
                if(x != 0)
                    left = Bubbels1[x - 1, y].GetType == Bubbels1[x, y].GetType && Bubbels1[x - 1, y].IsAlive;
                if(x != 11)
                    right = Bubbels1[x + 1, y].GetType == Bubbels1[x, y].GetType && Bubbels1[x + 1, y].IsAlive;
                if(y != 0)
                    up = Bubbels1[x, y - 1].GetType == Bubbels1[x, y].GetType && Bubbels1[x, y - 1].IsAlive;
                if(y != 11)
                    down = Bubbels1[x, y + 1].GetType == Bubbels1[x, y].GetType && Bubbels1[x, y + 1].IsAlive;
                if (left)
                {
                    Bubbels1[x, y].IsAlive = false;
                    checkIfNeighbors(x - 1, y);
                }
                if (right)
                {
                    Bubbels1[x, y].IsAlive = false;
                    checkIfNeighbors(x + 1, y);
                }
                if (up)
                {
                    Bubbels1[x, y].IsAlive = false;
                    checkIfNeighbors(x, y - 1);
                }
                if (down)
                {
                    Bubbels1[x, y].IsAlive = false;
                    checkIfNeighbors(x, y + 1);
                }
        }
