    static uint[] UnpackUint32(string filename)
    {
        var retval = new List<uint>();
        using (var filestream = System.IO.File.Open(filename, System.IO.FileMode.Open))
        {
            using (var binaryStream = new System.IO.BinaryReader(filestream))
            {
                var pos = 0;
                while (pos < binaryStream.BaseStream.Length)
                {
                    retval.Add(binaryStream.ReadUInt32());
                    pos += 4;
                }
            }
        }
        return retval.ToArray();
    }
