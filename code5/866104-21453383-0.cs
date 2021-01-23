        public static string MakeSha(string Mystr)
        {
            SHA1CryptoServiceProvider Crpyt = new SHA1CryptoServiceProvider();
            byte[] buf = ASCIIEncoding.ASCII.GetBytes(Mystr);
            return BitConverter.ToString(Crpyt.ComputeHash(buf)).Replace("-", "").ToUpper();
        }
