    MemoryStream xmlStream = new MemoryStream();
    using (FileStream stream = File.OpenRead(path))
    {
        int offset = 0, bytesRead = 0;
        // arbitrary size...whatever you think is reasonable would be fine
        byte[] buffer = new byte[1024];
        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            bool found = false;
            for (int i = 0; i < bytesRead; i++)
            {
                if (buffer[i] == 29)
                {
                    offset += i;
                    found = true;
                    xmlStream.Write(buffer, 0, i - 1);
                    break;
                }
            }
            if (found)
            {
                break;
            }
            offset += bytesRead;
            xmlStream.Write(buffer, 0, bytesRead);
        }
        if (bytesRead > 0)
        {
            // found byte 29 at offset "offset"
            xmlStream.Position = 0;
            // pass "xmlStream" object to your preferred XML-parsing API to
            // parse the XML, or just return it or "xmlStream.ToArray()" as
            // appropriate to the caller to let the caller deal with it.
        }
        else
        {
            // byte 29 not found!
        }
    }
