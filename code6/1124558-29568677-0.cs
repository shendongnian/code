    public static void Main()
    {
        var i = 1;
        while (true)
        {
            var screenSize = Screen.PrimaryScreen.Bounds.Size;
            try
            {                
                var bmpScreenshot = new Bitmap(screenSize.Width, screenSize.Height);
                var g = Graphics.FromImage(bmpScreenshot);
                g.CopyFromScreen(0, 0, 0, 0, screenSize);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception ignored: {0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Iteration #{0}", i++);
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
