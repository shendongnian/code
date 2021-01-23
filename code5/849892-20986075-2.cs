        public string HashPassword(string password, string passwordSalt)
        {
            int saltSize = 128 / 8;//128 bits = 16 bytes
            int PBKDF2SubkeyLength = 256 / 8; //256 bits = 32 bytes
            byte[] salt;
            byte[] subkey;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltSize, 1000))
            {
                salt = deriveBytes.Salt;
                subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
            }
            byte[] outputBytes = new byte[1 + saltSize + PBKDF2SubkeyLength];
            Buffer.BlockCopy(salt, 0, outputBytes, 1, saltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + saltSize, PBKDF2SubkeyLength);
            return Convert.ToBase64String(outputBytes);
        }
