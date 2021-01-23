            enum DrawResult
            {
                Draw,
                NotDraw
            }
            bool draw = true;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (char.IsWhiteSpace(matrix[row, col]))
                    {
                        draw = false;
                        break;
                    }
                }
            }
            if (draw)
            {
                return DrawResult.Draw; //return D for draw
            }
            return DrawResult.NotDraw
