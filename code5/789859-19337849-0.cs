    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    namespace WaveTestRead
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                using (var waveReader = new WaveReader())
                {
                    if (!waveReader.Open("wavetest.wav"))
                    {
                        Console.WriteLine("Failed to read file.");
                        return;
                    }
    
                    if (!waveReader.ReadFmt())
                    {
                        Console.WriteLine("Failed to read fmt.");
                        return;
                    }
    
                    // this method is not defined...
                    //waveReader.ReadData();
                }
    
            }
        }
    
        class WaveReader : IDisposable
        {
            FileInfo m_fInfo;
            FileStream m_fStream;
            BinaryReader m_binReader;
    
            // RIFF chunk
            byte[] chunkID;
            UInt32 chunkSize;
            byte[] format;
    
            // fmt subchunk
            byte[] fmtChunkID;
            UInt32 fmtChunkSize;
            UInt16 audioFormat;
            UInt16 numChannels;
            UInt32 sampleRate;
            UInt32 byteRate;
            UInt16 blockAssign;
            UInt16 BitsPerSample;
    
            // data subchunk
            byte[] dataChunkID;
            UInt32 dataChunkSize;
            byte[] data8L;              // 8-bit left channel
            byte[] data8R;              // 8-bit right channel
            Int16[] data16L;           // 16-bit left channel
            Int16[] data16R;           // 16-bit right channel
            int numSamples;
    
            public WaveReader()
            {
    
            }
    
            public bool Open(String filename)
            {
                string str;
                m_fInfo = new FileInfo(filename);
                m_fStream = m_fInfo.OpenRead();
                m_binReader = new BinaryReader(m_fStream);
    
                chunkID = new byte[4];
                format = new byte[4];
    
                chunkID = m_binReader.ReadBytes(4);
                chunkSize = m_binReader.ReadUInt32();
                format = m_binReader.ReadBytes(4);
    
                str = System.Text.ASCIIEncoding.ASCII.GetString(chunkID, 0, 4);
                if (str != "RIFF")
                    return false;
    
                str = System.Text.ASCIIEncoding.ASCII.GetString(format, 0, 4);
                if (str != "WAVE")
                    return false;
    
                //if (ReadFmt() == false)
                //    return false;
                //if (ReadData() == false)
                //    return false;
    
                return true;
            }
    
            public bool ReadFmt()
            {
                fmtChunkID = new byte[4];
                fmtChunkID = m_binReader.ReadBytes(4);
    
                string str = System.Text.ASCIIEncoding.ASCII.GetString(fmtChunkID, 0, 4);
                if (str != "fmt ")
                    return false;
    
                fmtChunkSize = m_binReader.ReadUInt32();
                audioFormat = m_binReader.ReadUInt16();
                numChannels = m_binReader.ReadUInt16();
                sampleRate = m_binReader.ReadUInt32();
                byteRate = m_binReader.ReadUInt32();
                blockAssign = m_binReader.ReadUInt16();
                BitsPerSample = m_binReader.ReadUInt16();
    
                return true;
            }
    
            public void Dispose()
            {
                if (m_fStream != null)
                    m_fStream.Dispose();
            }
        }
    }
