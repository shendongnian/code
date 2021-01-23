    string fileName = "C:\\FakeFilePath";
    using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
    using (StreamReader sr = new StreamReader(stream, Encoding.ASCII))
    using (StreamWriter writer = new StreamWriter(stream, Encoding.ASCII))
    {
        int lineCount = 0;
        String line;
        while ((line = sr.ReadLine()) != null)
        {
            if (line.Contains(users[m.GetInt(0)].username))
            {
                // Offset is the offset of the line itself, plus
                // the length of the name field (the name field doesn't
                // need to be written because it's already the right
                // value!)
                int byteOffset = (lineCount * 20) + 14;
                writer.BaseStream.Position = byteOffset;
                writer.Write(users[m.GetInt(0)].rupees.ToString("D4"));
                break;
            }
            lineCount++;
        }
    }
