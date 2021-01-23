        public static DateTime ConvertHFSDate(byte[] bytes) {
            if (bytes.Length != 4) throw new ArgumentException();
            return new DateTime(1904, 1, 1, 0, 0, 0, DateTimeKind.Local).AddSeconds(
                      BitConverter.ToUInt32(bytes, 0));
        }
