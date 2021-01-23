    private static void WriteZipFile(List<string> filesToZip, string path, int compression)
    {
    if (compression < 0 || compression > 9)
        throw new ArgumentException("Invalid compression rate.");
    if (!Directory.Exists(new FileInfo(path).Directory.ToString()))
        throw new ArgumentException("The Path does not exist.");
    foreach (string c in filesToZip)
        if (!File.Exists(c))
            throw new ArgumentException(string.Format("The File{0}does not exist!", c));
    Crc32 crc32 = new Crc32();
    ZipOutputStream stream = new ZipOutputStream(File.Create(path));
    stream.SetLevel(compression);
    for (int i = 0; i < filesToZip.Count; i++)
    {
        ZipEntry entry = new ZipEntry(Path.GetFileName(filesToZip[i]));
        entry.DateTime = DateTime.Now;
        using (FileStream fs = File.OpenRead(filesToZip[i]))
        {
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            entry.Size = fs.Length;
            fs.Close();
            crc32.Reset();
            crc32.Update(buffer);
            entry.Crc = crc32.Value;
            stream.PutNextEntry(entry);
            stream.Write(buffer, 0, buffer.Length);
        }
    }
    stream.Finish();
    stream.Close();
