    FileStream fs;
    BinaryReader br;
    List<ARecord> theRecords;
    class ARecord
    {
        public string name { get; set; }
        public Image img1 { get; set; }
        public Image img2 { get; set; }
    }
    int readFile(string filePath)
    {
        fs = new FileStream(filePath, FileMode.Open);
        br = new BinaryReader(fs, Encoding.UTF8);
        theRecords = new List<ARecord>();
        ARecord record = getNextRecord();
        while (record != null)
        {
            theRecords.Add(record);
            record = getNextRecord();
        }
        return theRecords.Count;
    }
    ARecord getNextRecord()
    {
        ARecord record = new ARecord ();
        MemoryStream ms;
        System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
        byte[] sepImg1 = enc.GetBytes(@"!=IMG1=");
        byte[] sepImg2 = enc.GetBytes(@"~\IMG2=");
        byte[] sepRec = enc.GetBytes(@"^!\r\n");
        record.name = enc.GetString(readToSep(sepImg1));
        ms = new MemoryStream(readToSep(sepImg2));
        if (ms.Length <= 0) return null;             // check for EOF
        record.img1 = Image.FromStream(ms);
        ms = new MemoryStream(readToSep(sepRec));
        record.img2 = Image.FromStream(ms);
        return record;
    }
    byte[] readToSep(byte[] sep)
    {
        List<byte> data = new List<byte>();
        bool eor = false;
        int sLen = sep.Length;
        int sPos = 0;
        while (br.BaseStream.Position < br.BaseStream.Length && !eor )
        {
            byte b = br.ReadByte();
            data.Add(b);
            if (b != sep[sPos]) { sPos = 0; }
            else if (sPos < sLen - 1) sPos++; else eor = true;
        }
        if (data.Count > sLen ) data.RemoveRange(data.Count - sLen , sLen );
        return data.ToArray();
    }
