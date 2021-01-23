    using (var reader = new Mp3FileReader(mp3Path))
    {
        FileStream writer = null;      
        try
        {
            Mp3Frame frame;
            while ((frame = reader.ReadNextFrame()) != null)
            {           
                if (writer != null &&
                    (int)reader.CurrentTime.TotalSeconds - secsOffset >= splitLength)
                {   
                    writer.Dispose();
                    writer = null;
                    secsOffset = (int)reader.CurrentTime.TotalSeconds;              
                }
    
                if (writer == null)
                    writer = File.Create(Path.Combine(splitDir,
                        Path.ChangeExtension(mp3File,(++splitI).ToString("D4") + ".mp3")));
    
                writer.Write(frame.RawData, 0, frame.RawData.Length);
            }
        }
        finally
        {
            if(writer != null) writer.Dispose();
        }
    }
