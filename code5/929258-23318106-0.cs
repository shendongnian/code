     public static string GetSHA1Hex(string fileName)
        {
            string result = string.Empty;
            using (System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1.Create("SHA1"))
            using (System.IO.FileStream fs = System.IO.File.Open(fileName, System.IO.FileMode.Open))
            {
                byte[] b = sha1.ComputeHash(fs);
                result = ToHex(b);
            }
            return result;
        }
        public static string[] HexTbl = Enumerable.Range(0, 256).Select(v => v.ToString("X2")).ToArray();
        public static string ToHex(IEnumerable<byte> array)
        {
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (var v in array)
                s.Append(HexTbl[v]);
            return s.ToString();
        }
