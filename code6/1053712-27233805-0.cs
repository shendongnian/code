        void MyEventHandler(string message)
        {
            var s = new StreamWriter(_stream);
            s.WriteLine(message);
            s.Flush();
        }
