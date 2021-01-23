    // First 4 bytes are file format marker. Container file format
    // is RIFF (it's a tagged file format)
    streamWriter.Write(Encoding.ASCII.GetBytes("RIFF"));
    
    // Number of bytes, header + audio samples
    streamWriter.Write(36 + sampleCount * channelCount * samplingRate);
    
    // Beginning of chunk specific of WAVE files, it describe how
    // data are stored
    streamWriter.Write(Encoding.ASCII.GetBytes("WAVEfmt "));
    streamWriter.Write(16); // It's always 16 bytes
    
    // Audio stream is PCM (value 1)
    streamWriter.Write((UInt16)1);
    
    // Player will use these information to understand how samples
    // are stored in the stream.
    streamWriter.Write(channelCount);
    streamWriter.Write(samplingRate);
    streamWriter.Write(samplingRate * bytesPerSample * channelCount);
    streamWriter.Write(bytesPerSample * channelCount);
    streamWriter.Write((UInt16)(8 * bytesPerSample));
    
    // Now the chunk that contains audio stream, just add its marker
    // and its length then write all your samples (in the raw format you have)
    streamWriter.Write(Encoding.ASCII.GetBytes("data"));
    streamWriter.Write(sampleCount * bytesPerSample);
