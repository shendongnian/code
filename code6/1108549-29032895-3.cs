    public string ToSHA256(string value)
        {
            SHA256 sha256 =  SHA256.Create();
            byte[] hashData = sha256.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder returnValue = new StringBuilder();
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
                returnValue.Replace('2', '9');
                returnValue.Replace('8', '4');
                returnValue.Replace('1', '7');
            }
            return returnValue.ToString();
        }
