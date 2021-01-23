    const int MAX_BUFFER = 2048;
    byte[] Buffer = new byte[MAX_BUFFER];
    int BytesRead;
    DataTable data = new DataTable();
    using (System.IO.FileStream fileStream = new FileStream("Output1.bin", FileMode.Open, FileAccess.Read))
    while ((BytesRead = fileStream.Read(Buffer, 0, MAX_BUFFER)) != 0)
    {
    string text = (Convert.ToBase64String(Buffer));
    BinaryFormatter bformatter = new BinaryFormatter();
    MemoryStream stream = new MemoryStream();
    stream = new MemoryStream(Buffer);
    data = (DataTable)bformatter.Deserialize(stream);
    stream.Close();
    }
