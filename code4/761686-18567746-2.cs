    class Test1 : IDisposable
    {
        FileStream fs;
        Test1()
        {
            fs = new FileStream("c:\\test.txt", FileMode.Open);
        }
        public SomeMethod()
        {
            byte[] bufer = new byte[256];
            fs.Read(bufer, 0, 256);
        }
        public void Dispose()
        {
            if(fs != null)
            {
                fs.Dispose();
                fs = null;
            }
        }
    }
