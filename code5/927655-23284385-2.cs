    public static string ToHexString(this byte[] bytes)
        { 
            if(bytes == null || bytes.Length == null)
                return string.Empty;
            StringBuilder hexStringBuilder = new StringBuilder();
            foreach (byte @byte in bytes)
            {
                hexStringBuilder.Append(@byte.ToString("X2"));
            }
            return hexStringBuilder.ToString();
        }
