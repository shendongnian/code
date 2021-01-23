    private void DrawRectangle(int width, int height)
    {
        for (int y = 0; y < height; y++) 
        {
            for (int x = 0; x < width; x++) 
            {
                if (this.IsInsideRectangle(x, y))
                {
                    // Print either a star or a space.
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
        }
    }
    private bool IsInsideRectangle(int x, int y)
    {
        return y > 0 && ...
    }
