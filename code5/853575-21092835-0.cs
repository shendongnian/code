    namespace ConsoleApplication12
    {
    class Program
    {
        [DllImport("gdi32.dll")]
        private extern static int SetPixel(int hdc, int x, int y, int color);
        [DllImport("kernel32.dll")]
        private extern static int GetConsoleWindow();
        [DllImport("user32.dll")]
        private extern static int GetDC(int i);
        static void Main(string[] args)
        {
            int myCon = GetConsoleWindow();
            int myDC = GetDC(myCon);
            for (int i = 50; i < 150; i++)
            {
                for (int j = 50; j < 150; j++)
                {
                    if (i == 50 || i == 149 || j == 50 || j == 149)
                        SetPixel(myDC, i, j, 255*256*256 + 255*256 + 255);
                }
            }
            Console.ReadLine();
        }
    }
    }
