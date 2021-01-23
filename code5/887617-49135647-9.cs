    IEnumerable<string> lines = ...
    using (TextWriter writer = System.IO.File.CreateText(...))
    {
        using (TextReader reader = new EnumStringReader(lines);
        {
            // either write per char:
            while (reader.Peek() != -1)
            {
                char c = (char)reader.Read();
                writer.Write(c);
            } 
            // or write per line:
            string line = reader.ReadLine();
            // line is without newLine!
            while (line != null)
            {
                writer.WriteLine(line);
                line = reader.ReadLine();
            }
            // or write per block
            buffer buf = new char[4096];
            int nrRead = reader.ReadBlock(buf, 0, buf.Length)
            while (nrRead > 0)
            {
                writer.Write(buf, 0, nrRead);
                nrRead = reader.ReadBlock(buf, 0, buf.Length);
            }
        }
    }
