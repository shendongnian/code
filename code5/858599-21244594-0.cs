            // Write the float
            var f = 1.23456f;
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(f);
            writer.Flush();
            // Read 4 bytes to get the raw bytes (Ouch!)
            ms.Seek(0, SeekOrigin.Begin);
            var buffer = new char[4];
            var reader = new StreamReader(ms);
            reader.Read(buffer, 0, 4);
            for (int i = 0; i < 4; i++)
            {
                Console.Write("{0:X2}", (int)buffer[i]);
            }
            Console.WriteLine();
            // This is what you actually read: human readable text
            for (int i = 0; i < buffer.Length; i++)
            {
                Console.Write(buffer[i]);
            }
            Console.WriteLine();
            // This is what the float really looks like in memory.
            var bytes = BitConverter.GetBytes(f);
            for (int i = 0; i < bytes.Length; i++)
            {
                Console.Write("{0:X2}", (int)bytes[i]);
            }
            Console.ReadLine();
