    unsafe
    {
        var buffer = new byte[100]; // a C++ char is 1 byte
        fixed (byte* ptr = buffer)
        {
            Method1(ptr);
    
            while (true)
            {
                // WARNING: There's no locking here (see comment below)
                //          It may cause undefined behavior.
                var str = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(str);
                Thread.Sleep(100);
            }
        }
    }
