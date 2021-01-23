        public static string ByteArrayToDecimalString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder();
            string format = "{0}";
            foreach (byte b in ba)
            {
                hex.AppendFormat(format, b);
                format = " {0}";
            }
            return hex.ToString();
        }
