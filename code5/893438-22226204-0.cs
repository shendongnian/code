    //Author: Racil Hilan
    /// <summary>Defines the function used in generating the hash.</summary>
    public enum HashAlgorithm { MD5, SHA1, SHA256, SHA384, SHA512 }
    //Author: Racil Hilan
    /// <summary>Hashes a string using the specified algorithm.</summary>
    public static string HashString(string StringData, HashAlgorithm Algorithm) {
      System.Security.Cryptography.HashAlgorithm alg;
      switch (Algorithm) {
        case HashAlgorithm.MD5:
          alg = MD5.Create();
          break;
        case HashAlgorithm.SHA1:
          alg = SHA1.Create();
          break;
        case HashAlgorithm.SHA256:
          alg = SHA256.Create();
          break;
        case HashAlgorithm.SHA384:
          alg = SHA384.Create();
          break;
        case HashAlgorithm.SHA512:
        default:
          alg = SHA512.Create();
          break;
      }
      return HashString(StringData, alg);
    }
    //Author: Racil Hilan
    /// <summary>Hashes a string using the provided algorithm.</summary>
    private static string HashString(string StringData, System.Security.Cryptography.HashAlgorithm Algorithm) {
      byte[] Hashed = Algorithm.ComputeHash(Encoding.UTF8.GetBytes(StringData));
      return BytesToHex(Hashed);
    }
    //Author: Racil Hilan
    /// <summary>Converts a byte array to a hex string.</summary>
    private static string BytesToHex(byte[] bytes) {
      StringBuilder hex = new StringBuilder();
      foreach (byte b in bytes)
        hex.AppendFormat("{0:X2}", b);
      return hex.ToString();
    }
