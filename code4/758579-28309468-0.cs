        private string decoder(string value)
        {
            Regex lettersOnly = new Regex("^[0-9]|[A-Z]$");
            if ((value.Length % 4 == 0) && lettersOnly.Match(value).Success)
            {
                string data = FromHex(value);
                return data;
            }
            else
                return value;
        }      
     
        public static string FromHex(string hex)
        {
            short[] raw = new short[hex.Length / 4];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToInt16(hex.Substring(i * 4, 4), 16);
            }
            string s = "";
            //wtf encoding utf32 ride ahmagh kos sher pas mide
            foreach (var item in raw)
            {
                s += char.ConvertFromUtf32(item).ToString();
            }
            return s;
        }
