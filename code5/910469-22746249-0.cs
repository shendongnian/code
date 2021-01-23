        public static string Encrypt(int value)
        {
            return Convert.ToBase64String(BitConverter.GetBytes(value)).Replace("==","");
        }
        public static int Decrypt(string value)
        {
            if(value.Length!=6)
                throw new ArgumentException("Invalid length.");
            return BitConverter.ToInt32(Convert.FromBase64String(value + "=="),0);
        }
