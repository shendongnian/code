        public static string ConvertAndSwapHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                int j = i;
                if (j != 0)
                {
                    j = (j % 2 == 1 ? j-1 : j+1);
                }
                raw[j] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return System.Text.Encoding.UTF8.GetString(raw).Trim(' ', '\t', '\0');
        }
