            public static string MyHMACHash(string key, string message)
            {
                if (string.IsNullOrEmpty(key) || key.Length < 32)
                {
                    // error condition as you wanted more than 32 chars
                    return string.Empty;
                }
    
                using (var crypto = new HMACSHA256())
                {
                    crypto.Key = System.Text.Encoding.UTF8.GetBytes(key);
                    var hash = crypto.ComputeHash(System.Text.Encoding.UTF8.GetBytes(message));
    
                    // Following linq will create standard hex string representation
                    return hash.Select<byte, string>(a => a.ToString("x2"))
                        .Aggregate<string>((a, b) => string.Format("{0}{1}", a, b));
                }
            }
