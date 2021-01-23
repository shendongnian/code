    using System.IO;
    ...
        public static void SetJpegResolution(string path, int dpi) {
            using (var jpg = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) 
            using (var br = new BinaryReader(jpg)) {
                bool ok = br.ReadUInt16() == 0xd8ff;        // Check header
                ok = ok && br.ReadUInt16() == 0xe0ff;
                br.ReadInt16();                             // Skip length
                ok = ok && br.ReadUInt32() == 0x4649464a;   // Should be JFIF
                ok = ok && br.ReadByte() == 0;
                ok = ok && br.ReadByte() == 0x01;           // Major version should be 1
                br.ReadByte();                              // Skip minor version
                byte density = br.ReadByte();
                ok = ok && (density == 1 || density == 2);
                if (!ok) throw new Exception("Not a valid JPEG file");
                if (density == 2) dpi = (int)Math.Round(dpi / 2.56);
                var bigendian = BitConverter.GetBytes((short)dpi);
                Array.Reverse(bigendian);
                jpg.Write(bigendian, 0, 2);
                jpg.Write(bigendian, 0, 2);
            }
        }
