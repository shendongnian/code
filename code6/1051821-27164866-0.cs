            // Write bytes for test purpose
            byte[] bytes = Encoding.ASCII.GetBytes("Hello world from PC");
            port.Write(bytes, 0, 10);
            Thread.Sleep(100); // small delay
            port.Write(bytes, 10, 9); // next block
