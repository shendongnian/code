     public static string GetSalt(int saltSize)
            {
                Random r = new Random();
                StringBuilder strB = new StringBuilder("");
    
                while ((saltSize--) > 0)
                    strB.Append(alphanumeric[(int)(r.NextDouble() * alphanumeric.Length)]);
                return strB.ToString();
            }
    
    public static string HashPassword(string salt, string password)
            {
                string mergedPass = string.Concat(salt, password);
                return EncryptUsingMD5(mergedPass);
            }
    
    public static string EncryptUsingMD5(string inputStr)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    // Convert the input string to a byte array and compute the hash.
                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(inputStr));
    
                    // Create a new Stringbuilder to collect the bytes
                    // and create a string.
                    StringBuilder sBuilder = new StringBuilder();
    
                    // Loop through each byte of the hashed data 
                    // and format each one as a hexadecimal string.
                    for (int i = 0; i < data.Length; i++)
                        sBuilder.Append(data[i].ToString("x2"));
    
                    // Return the hexadecimal string.
                    return sBuilder.ToString();
                }
            }
