    public static string FromBase64(string base64Str, Encoding encoding = null)
    {
            if (string.IsNullOrWhiteSpace(base64Str))
            {
                return string.Empty;
            }
            byte[] bytes;
            try
            {
                bytes = System.Convert.FromBase64String(base64Str);
            }
            catch (FormatException)
            {
                return string.Empty;
            }
            var stringEncoding = encoding ?? Encoding.UTF8;
            return stringEncoding.GetString(bytes);
		}
