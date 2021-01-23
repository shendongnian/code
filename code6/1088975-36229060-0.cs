    class emptyRectangle:Shape
    {
        byte width;
        byte height;
        public emptyRectangle(byte width,byte height)
        {
            this.width = width;
            this.height = height;
        }
        public override void area()
        {
            Console.WriteLine("\n----------");
            for (int i = 0; i < height; i++)
            {
                Console.WriteLine("");
                
                for (int k = 0; k < width; k++)
                {
                    if (i > 0 && k > 0)
                    {
                        if (i < height - 1 && k < width - 1)
                        {
                            Console.Write(" ");
                        }
                        else
                            Console.Write('*');
                   }
                    else
                        Console.Write("*");
                }
            }
        }
    }
