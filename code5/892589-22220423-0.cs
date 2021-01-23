       static void WriteWavHeader(Stream stream, int dataLength)
            {
                //We need to use a memory stream because the BinaryWriter will close the underlying stream when it is closed
                using (var memStream = new MemoryStream(64))
                {
                    int cbFormat = 18; //sizeof(WAVEFORMATEX)
                    WAVEFORMATEX format = new WAVEFORMATEX()
                    {
                        wFormatTag = 1,
                        nChannels = 1,
                        nSamplesPerSec = 16000,
                        nAvgBytesPerSec = 32000,
                        nBlockAlign = 2,
                        wBitsPerSample = 16,
                        cbSize = 0
                    };
    
                    using (var bw = new BinaryWriter(memStream))
                    {
                        //RIFF header
                        WriteString(memStream, "RIFF");
                        bw.Write(dataLength + cbFormat + 4); //File size - 8
                        WriteString(memStream, "WAVE");
                        WriteString(memStream, "fmt ");
                        bw.Write(cbFormat);
    
                        //WAVEFORMATEX
                        bw.Write(format.wFormatTag);
                        bw.Write(format.nChannels);
                        bw.Write(format.nSamplesPerSec);
                        bw.Write(format.nAvgBytesPerSec);
                        bw.Write(format.nBlockAlign);
                        bw.Write(format.wBitsPerSample);
                        bw.Write(format.cbSize);
    
                        //data header
                        WriteString(memStream, "data");
                        //bw.Write(dataLength);
                        bw.Write(dataLength);
                        memStream.WriteTo(stream);
                    }
                }
            }
