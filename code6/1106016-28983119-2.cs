    static void Main(string[] args)
        {
            string path = @"C:\Visual Studio 2013\Projects\WcfTester\WcfTester\bin\Debug\WcfTester.exe";
            for (int i = 0; i < 5; i++)
            {
                Process.Start(path);
            }
        }
