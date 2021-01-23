    byte[] ReadAsNullTerminatedByteArray(string filename)
    {
        using (FileStream fs = File.OpenRead(filename))
        {
            byte[] bytes = new byte[fs.Length+1];
            fs.Read(bytes, 0, fs.Length);
            return bytes;
        }
    }
