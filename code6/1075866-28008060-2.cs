    internal static class Program
    {
        private static void Main()
        {
            using (new KeyboardHook())
                Application.Run();
        }
    }
