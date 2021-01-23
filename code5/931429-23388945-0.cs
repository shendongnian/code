        private static string _basePath = "C:/TEST/vikas/";
        static void Main(string[] args)
        {
            Parallel.For(0, 10000, (index) =>
                {
                    string filename = Path.Combine(_basePath, "_" + index.ToString());
                    // filename is unique
                }
            );
        }
