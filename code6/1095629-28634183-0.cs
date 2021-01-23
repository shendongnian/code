    string nMP3Folder = "FOLDER PATH";
    string nMP3SourceFilename = "SOURCE MP3 FILENAME";
    string nMP3OutputFilename = "YOUR OUTPUT MP3 FILENAME";
    using (Mp3FileReader rdr = new Mp3FileReader(nMP3Folder + nMP3SourceFilename))
    {
        int count = 1;
        Mp3Frame objmp3Frame = reader.ReadNextFrame();
        System.IO.FileStream _fs = new System.IO.FileStream(nMP3Folder + nMP3OutputFilename, System.IO.FileMode.Create, System.IO.FileAccess.Write);
    while (objmp3Frame != null)
    {
        if (count > 500) //retrieve a sample of 500 frames
            return;
        _fs.Write(objmp3Frame.RawData, 0, objmp3Frame.RawData.Length);
        count = count + 1;
        objmp3Frame = rdr.ReadNextFrame();
     }
     _fs.Close();
    }
