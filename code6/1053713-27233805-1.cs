        void MyEventHandler(string message)
        {
            using (var s = new StreamWriter(_stream, Encoding.UTF8, 1024, true))
            {
                 s.WriteLine(message);
            }
        }
