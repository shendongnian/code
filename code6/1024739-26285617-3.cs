    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            using (new MouseRightClickDisable())
                Application.Run();
        }
    }
