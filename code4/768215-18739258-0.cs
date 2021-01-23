    void updatefile(string filename)
    {
        char[] buffer = new char[17];
        string tempfile = Path.GetTempFileName();
        StreamWriter writer = new StreamWriter(tempfile);
        StreamReader reader = new StreamReader(filename);
        while (!reader.EndOfStream)
        {
            writer.Write(buffer, 0, reader.Read(buffer, 0, 17));
            writer.Write(":");
            if (!reader.EndOfStream)
                writer.WriteLine(reader.ReadLine());
        }
        writer.Close();
        reader.Close();
        File.Copy(tempfile, filename, true);
        File.Delete(tempfile);
    }
