        public static string Hex2Str(string hexString)
        {
            var sb = new StringBuilder();
            var len = hexString.Length / 2;
            for (var i = 0; i < len; i++)
            {
                // Convert the number expressed in base-16 to an integer. 
                int value = Convert.ToInt32(hexString.Substring(i * 2, 2), 16);
                string stringValue = Char.ConvertFromUtf32(value);
                sb.Append(stringValue);
            }
            return sb.ToString();
        }
