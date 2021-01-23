    bool AllEmpty(int[,] board, int width, int height)
    {
      for (int y = 0; y < height; ++y)
      {
        for (int x = 0; x < width; ++x)
        {
          if (board[y, x] != 0)
          {
            return false;
          }
        }
      }
      return true;
    }
