    public string Float2Hex(float fNum)
    {
        MemoryStream ms = new MemoryStream(sizeof(float));
        StreamWriter sw = new StreamWriter(ms);
        // Write the float to the stream
        sw.Write(fNum);
        sw.Flush();
        // Re-read the stream
        ms.Seek(0, SeekOrigin.Begin);
        byte[] buffer = new byte[4];
        ms.Read(buffer, 0, 4);
        // Convert the buffer to Hex
        StringBuilder sb = new StringBuilder();
        foreach (byte b in buffer)
            sb.AppendFormat("{0:X2}", b);
        sw.Close();
        return sb.ToString();
    }
