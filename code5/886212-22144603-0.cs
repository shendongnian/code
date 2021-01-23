    byte[] Rec = new byte[1024];
    FileInfo file_info = new FileInfo(import.FileName);
    long a = file_info.Length;
    int rec_num_to_read = Dgv.CurrentRow.Index + 1;
    
    using (FileStream Fs = new FileStream(import.FileName, FileMode.Open, FileAccess.Read))
    using (BinaryReader Br = new BinaryReader(Fs))
    {
        while ((a = Br.Read(Rec, 0, 1024)) > 0)
        {
            Fs.Seek(rec_num_to_read * 1024, SeekOrigin.Begin); // I moved this out of the foreach loop
                       
            foreach (var rec in Rec)
            {
                Label_Product1.Text = DecodeString(Rec, 3, 12);
                // Some more info to decode
            }
        }
    }
