        static public string DeMangleCode(string argMangledCode1)
        {
            byte[] argMangledCode = Encoding.Default.GetBytes(argMangledCode1);
            List<byte> unencrypted = new List<byte>();
            for (int temp = 0; temp < argMangledCode.Length; temp++)
            {
                unencrypted.Add((byte)(argMangledCode[temp] ^ (434 + temp) % 255));
            }
            return Encoding.Default.GetString(unencrypted.ToArray());
        }
