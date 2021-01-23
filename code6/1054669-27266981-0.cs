        private static readonly MemoryStream _reader;
        private static object _data;
        static Program()
        {
            _reader = new MemoryStream();
        }
        private static void Main(string[] args)
        {
            Task.Run(async delegate()
            {
                while (true)
                {
                    if (_data == null)
                        await Task.Delay(1000); // so the cpu can have rest
                                                // you can lower the value of this
                    else
                    {
                        // read here
                        await Task.Delay(1000);
                    }
                }
            });
        }
