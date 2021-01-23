    static Decision[,] YjMatrix()
        {
            Decision[,] d = new Decision[1, int cols];
            for (int col = 0; col < cols; col++)
                d[0, col] = new Decision(Domain.Boolean, "Y" + col);
            return d;
        }
