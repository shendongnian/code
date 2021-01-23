    public string HashItThePHPWay(string hashMe)
            {
                var sha = new SHA1CryptoServiceProvider();
                string b64 = ByteArrayToString(Encoding.ASCII.GetBytes(hashMe));
                var b64Bytes = Encoding.ASCII.GetBytes(b64);
                var result = sha.ComputeHash(b64Bytes);
                return BitConverter.ToString(result).Replace("-", "").ToLower();
            }
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString().ToLower();
        }
