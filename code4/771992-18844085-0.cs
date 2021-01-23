        public static byte[] GetRawMp3Frames(string filename)
        {
            using(MemoryStream output = new MemoryStream()) {
                Mp3FileReader reader = new Mp3FileReader(filename);
                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                {
                    output.Write(frame.RawData, 0, frame.RawData.Length);
                }
                return output.ToArray(); 
            }
       }
