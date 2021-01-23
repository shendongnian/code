        public static DateTime ConvertUnixDate(byte[] bytes) {
            if (bytes.Length != 4) throw new ArgumentException();
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(
                      BitConverter.ToUInt32(bytes, 0));
        }
