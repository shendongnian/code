        public static byte[] ReadBytes(Stream s, int size, bool littleEndian) {
            var bytes = new byte[size];
            var len = s.Read(bytes, 0, size);
            if (len != size) throw new InvalidOperationException("Unexpected end of file");
            if (BitConverter.IsLittleEndian != littleEndian) Array.Reverse(bytes);
            return bytes;
        }
