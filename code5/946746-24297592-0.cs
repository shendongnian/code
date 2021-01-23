    // get back the file from the blob content
    long lengthOfStream = cobaltFile.GetCobaltFilePartition(FilePartitionId.Content).GetStream(RootId.Default.Value).Length;
    byte[] mybytes = new byte[lengthOfStream];
    cobaltFile.GetCobaltFilePartition(FilePartitionId.Content).GetStream(RootId.Default.Value).ReadIfPossible(0, mybytes, 0, Convert.ToInt32(lengthOfStream));
    // Open file for reading
    System.IO.FileStream _FileStream =
    new System.IO.FileStream("C:\\WOPI OWA WORD EDITOR\\OWA_Source_Documents\\output.docx", System.IO.FileMode.Create, System.IO.FileAccess.Write);
    // Writes a block of bytes to this stream using data from
    // a byte array.
    _FileStream.Write(mybytes, 0, mybytes.Length);
    // close file stream
    _FileStream.Close();
