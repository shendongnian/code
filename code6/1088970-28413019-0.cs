    private void DrawFillRectangle(int width, int height)
    {
        for (int y = 0; y < height; y++) 
        {
            for (int x = 0; x < width; x++) 
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
