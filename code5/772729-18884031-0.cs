        internal static string EscapeUriDataStringRfc3986(string value)
        {
            StringBuilder escaped = new StringBuilder();
            string validChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-._~";
            foreach (char c in value)
            {
                if(validChars.Contains(c.ToString())){
                    escaped.Append(c);
                } else {
                    escaped.Append("%" + Convert.ToByte(c).ToString("x2").ToUpper());
                }
            }
            // Return the fully-RFC3986-escaped string.
            return escaped.ToString();
        }
