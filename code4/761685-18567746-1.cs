    class Test1
    {
        FileStream fs;
        Test1()
        {
            using (var fileStream = new FileStream("c:\\test.txt", FileMode.Open))
            {
                fs = fileStream;
            }
        }
        public SomeMethod()
        {
            byte[] bufer = new byte[256];
            fs.Read(bufer, 0, 256);
        }
    }
