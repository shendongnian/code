    private void DrawRectangle(int width, int height)
    {
        for (int y = 0; y < height; y++) 
        {
            for (int x = 0; x < width; x++) 
            {
                if (y > 0)
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
