    public class Key {
      public string Password { get; set; }
      public byte[] Salt { get; set; }
      public string Vector { get; set; }
      public PaddingMode? Padding { get; set; }
    }
    public class AesCryptor {
      private const int HASH_SIZE = 32;
      private ICryptoTransform m_Decryptor;
      private ICryptoTransform m_Encryptor;
      private TimeSpan m_Validity;
      // Methods
      public AesCryptor(Key key, TimeSpan validity) {
        if (key == null) {
          throw new ArgumentNullException("key");
        }
        m_Validity = validity;
        using (AesManaged aes = new AesManaged()) {
          aes.Mode = CipherMode.CBC;
          aes.Key = new Rfc2898DeriveBytes(key.Password, key.Salt).GetBytes(aes.KeySize / 8);
          aes.IV = Encoding.ASCII.GetBytes(key.Vector);
          if (key.Padding.HasValue) {
            aes.Padding = key.Padding.Value;
          }
          m_Encryptor = aes.CreateEncryptor();
          m_Decryptor = aes.CreateDecryptor();
        }
      }
      private static bool CompareArray(byte[] first, byte[] second) {
        if (first.Length != second.Length) {
          return false;
        }
        for (int i = 0; i < first.Length; i++) {
          if (first[i] != second[i]) {
            return false;
          }
        }
        return true;
      }
      public byte[] Decrypt(byte[] encryptedData) {
        byte[] hash;
        if (encryptedData == null) {
          throw new ArgumentNullException("encryptedData");
        }
        byte[] buffer = m_Decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        using (SHA256 sha = SHA256.Create()) {
          hash = sha.ComputeHash(buffer, 0, buffer.Length - HASH_SIZE);
        }
        byte[] orginalHash = new byte[HASH_SIZE];
        Buffer.BlockCopy(buffer, buffer.Length - HASH_SIZE, orginalHash, 0, HASH_SIZE);
        if (!CompareArray(orginalHash, hash)) {
          throw new Exception("Hash match failure.");
        }
        if (m_Validity != TimeSpan.Zero) {
          DateTime timestamp = new DateTime(BitConverter.ToInt64(buffer, (buffer.Length - HASH_SIZE) - 8));
          TimeSpan delta = (TimeSpan)(DateTime.Now - timestamp);
          if (delta > m_Validity) {
            throw new Exception("Timestamp too old.");
          }
        }
        byte[] result = new byte[(buffer.Length - HASH_SIZE) - 8];
        Buffer.BlockCopy(buffer, 0, result, 0, (buffer.Length - HASH_SIZE) - 8);
        return result;
      }
      public byte[] Encrypt(byte[] data) {
        byte[] hash;
        if (data == null) {
          throw new ArgumentNullException("data");
        }
        byte[] buffer = new byte[(data.Length + 8) + HASH_SIZE];
        Buffer.BlockCopy(data, 0, buffer, 0, data.Length);
        Buffer.BlockCopy(BitConverter.GetBytes(DateTime.Now.Ticks), 0, buffer, data.Length, 8);
        using (SHA256 sha = SHA256.Create()) {
          hash = sha.ComputeHash(buffer, 0, buffer.Length - HASH_SIZE);
        }
        Buffer.BlockCopy(hash, 0, buffer, buffer.Length - HASH_SIZE, HASH_SIZE);
        return m_Encryptor.TransformFinalBlock(buffer, 0, buffer.Length);
      }
    }
