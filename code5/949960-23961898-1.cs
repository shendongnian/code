    public static void Main()
    {
            int times = 9999;
            Parallel.For(1, times, i =>
            {
                Console.WriteLine("produce " + i.ToString());
                using (Image img = new Bitmap(times, 1600))
                {
                    using (Image resized = new Bitmap(img, 10, 10))
                    {
                        Console.WriteLine("resize" + i.ToString());
                    }
                    
                }
                Console.WriteLine("dispose" + i.ToString());
            });     
    }
