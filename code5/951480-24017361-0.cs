    public static string GetUniqueKey() {
      int size = 16;
      byte[] data = new byte[size];
      RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
      crypto.GetBytes(data);
      return BitConverter.ToString(data).Replace("-", String.Empty);
    }
