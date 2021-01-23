        public static string ConvertAndSwapHex(string hexString)
        {
            var charString = new StringBuilder();
            for (var i = 0; i < hexString.Length; i += 4)
            {
                charString.Append(Convert.ToChar(Convert.ToUInt32(hexString.Substring(i + 2, 2), 16)));
                charString.Append(Convert.ToChar(Convert.ToUInt32(hexString.Substring(i, 2), 16)));
            }
            return charString.ToString();
        }
