    using (var bw = new BinaryWriter(File.Open("c:\\Tmp\\" + a.Name, FileMode.OpenOrCreate,
        FileAccess.Write, FileShare.Read))
    {
        bw.Write(((FileAttachment)a).Content);
    }
