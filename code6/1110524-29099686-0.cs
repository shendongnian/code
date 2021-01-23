    using (FileStream stream = File.OpenRead(path))
    {
        int offset = 0, bytesRead = 0;
        byte[] buffer = new byte[1024]
        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            bool found = false;
            for (int i = 0; i < bytesRead; i++)
            {
                if (buffer[i] == 29)
                {
                    offset += i;
                    found = true;
                    break;
                }
            }
            if (found)
            {
                break;
            }
            offset += bytesRead;
        }
        if (bytesRead > 0)
        {
            // found byte 29 at offset "offset"
        }
        else
        {
            // byte 29 not found!
        }
    }
