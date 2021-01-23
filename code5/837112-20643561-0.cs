        string stringToHex(string astr)
        {
            return StringToHex(astr, System.Text.Encoding.Default);
        }
        string stringToHex(string astr, System.Text.Encoding enc)
        {
            return bytesToHex(enc.GetBytes(astr));
        }
        string bytesToHex(byte[] bytes)
        {
            if (bytes.Length == 0) return "";
            var sb = new StringBuilder();
            var n = bytes.Length - 1;
            for(int i = 0; i < n; i++) 
            {
                sb.Append(byteToHex(bytes[i]));
                sb.Append(" ");
            }
            sb.Append(byteToHex(bytes[n]));
            return sb.ToString();
        }
        string byteToHex(byte b)
        {
            string hx = Convert.ToString(b, 16).ToUpper();
            if (hx.Length < 2) hx = "0" + hx;
            return hx;
        }
