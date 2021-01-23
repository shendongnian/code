    private string[] UnpackStrings(string filename)
    {
        var retval = new List<string>();
        using (var filestream = System.IO.File.Open(filename, System.IO.FileMode.Open))
        {
            using (var binaryStream = new System.IO.BinaryReader(filestream))
            {
                var pos = 0;
                while ((pos + 4) <= binaryStream.BaseStream.Length)
                {
                    // readthe length of the string
                    var len = binaryStream.ReadUInt32();
                    
                    // read the bytes of the string
                    var byteArr = binaryStream.ReadBytes((int) len);
                    // cast this bytes to a char and append them to a stringbuilder
                    var sb = new StringBuilder();
                    foreach (var b in byteArr)
                        sb.Append((char)b);
                    // add the new string to our collection of strings
                    retval.Add(sb.ToString());
                    // calculate start position of next value
                    pos += 4 + (int) len;
                }
            }
        }
        return retval.ToArray();
    }
