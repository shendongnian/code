    private static string CreateSalt()
            {
                //Generate a cryptographic random number.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] buff = new byte[32];
                rng.GetBytes(buff);
                //Return a Base64 string representation of the random number.
                return Convert.ToBase64String(buff);
            }
            private static string CreatePasswordHash(string pwd, string salt)
            {
                string saltAndPwd = String.Concat(pwd, salt);
                string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "sha1");
                return hashedPwd;
            }
