    using (NetworkStream stream = client.GetStream())
    {
        using(BinaryReader br = new BinaryReader(stream))
        {
            byte[] buffer = br.ReadBytes(MaxDownloadBytes);
            using (FileStream filestream = new FileStream(savingPath, FileMode.CreateNew,  FileAccess.Write))
            {
                filestream.Write(buffer, 0, buffer.Length);
            }
        }
    }
