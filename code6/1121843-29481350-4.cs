    private string PasswordEncode(string password, byte[] salt ) {
          var deriver2898 = new Rfc2898DeriveBytes(password, salt,64000); // approx 300msecs
          byte[] hash = deriver2898.GetBytes(20); // 
          //    return hash;
          // If you dont like storing bytes, use a string
          return Convert.ToBase64String(hash);
    }
       
    // himalayan pink rock salt... the best kind
        public byte[] GenerateSalt(int size = 64) {
            using (var crypto = new RNGCryptoServiceProvider()) {
                var bytes = new byte[size];
                crypto.GetBytes(bytes); //get a bucket of very random bytes
                return bytes;
            }
        }
