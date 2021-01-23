    private void SplitUnwantedHeader(string myFile)
    {
        const int skipBytes = 128;
        using (FileStream fs = File.Open(myFile, FileMode.Open))
        {
            // Write the skipped bytes to file A
            using (FileStream skipBytesFS = File.Open("FileA.txt", FileMode.Create))
            {
                byte[] skipBytesBuffer = new byte[skipBytes];
                fs.Read(skipBytesBuffer, 0, skipBytes);
                skipBytesFS.Write(skipBytesBuffer, 0, skipBytes);
                skipBytesFS.Flush();
            }
            // Write the rest of the bytes to file B
            using (FileStream outputFS = File.Open("FileB.txt", FileMode.Create))
            {
                long length = fs.Length - skipBytes;
                for (long i = 0; i < length; i++)
                    outputFS.WriteByte((byte)fs.ReadByte());
                outputFS.Flush();
            }
        }
    }
