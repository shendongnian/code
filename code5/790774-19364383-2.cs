    public void checkIfNeighbors(int x, int y, bool inRecursion)
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
                    checkIfNeighbors(x - 1, y, true);
                }
                if (right)
                {
                    Bubbels1[x, y].IsAlive = false;
                    checkIfNeighbors(x + 1, y, true);
                }
                if (up)
                {
                    Bubbels1[x, y].IsAlive = false;
                    checkIfNeighbors(x, y - 1, true);
                }
                if (down)
                {
                    Bubbels1[x, y].IsAlive = false;
                    checkIfNeighbors(x, y + 1, true);
                }
                if (inRecursion)
                {
                    Bubbels1[x, y].IsAlive = false;
                }
        }
