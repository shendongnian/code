    class Program
    {
        static void Main()
        {
            for (int i = 0; i <= 10; i++)
            {
                SaveConfiguration();
                Thread.Sleep(500);
            }
        }
        private static void SaveConfiguration()
        {
            string fileName = System.IO.Path.Combine(@"Config\File\Dir", String.Format("Config{0:yyyyMMddHHmmss}.ini", DateTime.UtcNow));
            System.IO.File.WriteAllText(fileName, "File contents");
        }
    }
