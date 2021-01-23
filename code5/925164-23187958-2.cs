    private static int playerX, playerY;
    public static void MovePlayer(int x, int y)
    {
         table[playerX, playerY] = "-"; //Remove old position
         table[x, y] = "P"; //Update new position
         playerX = x; //Save current position
         playerY = y;
         UpdateGrid();
    }
