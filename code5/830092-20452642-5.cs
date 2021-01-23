        public static CREC10 FromStream(Stream stream)
        {
            CREC10 result;
            using (BinaryReader reader = new BinaryReader(stream))
            {
                result.C0RT = reader.ReadInt32();
                result.C0KEY1 = reader.ReadInt32();
                result.C10VAFT = new string[14];
                for (int i=0; i<result.C10VAFT.Length; i++)
                {
                    result.C10VAFT[i] = Encoding.ASCII.GetString(reader.ReadBytes(20));
                }
                result.C10VH1H = Encoding.ASCII.GetString(reader.ReadBytes(20));
            }
            return result;
        }
