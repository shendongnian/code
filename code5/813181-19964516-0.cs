        private string GetHashedString(string _PW)
        {
            string _HashedPW = "";
            SHA512 sha = new SHA512CryptoServiceProvider();
            byte[] result;
            StringBuilder strBuilder = new StringBuilder();
            sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(_PW));
            result = sha.Hash;
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            _HashedPW = strBuilder.ToString();
            return _HashedPW;
        }
