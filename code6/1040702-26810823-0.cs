    static class DesCsp
    {
    
      public static byte[] EncryptBytes(byte[] input, byte[] desKey, byte[] desIV)
      {
        DES des = new DESCryptoServiceProvider();
        des.Padding = PaddingMode.None;
        var enc = des.CreateEncryptor(desKey, desIV);
        return enc.TransformFinalBlock (input, 0, input.Length);    
      }
    
      public static byte[] DecryptBytes(byte[] encryptedOutput, byte[] desKey, byte[] desIV)
      {
        DES des = new DESCryptoServiceProvider();
        des.Padding = PaddingMode.None;
        var dec = des.CreateDecryptor(desKey, desIV);
        return dec.TransformFinalBlock(encryptedOutput, 0, encryptedOutput.Length);
      }
    
      public static string EncryptHexStrings(string input, byte[] desKey, byte[] desIV)
      {
        byte[] bytes = HexStringToByteArray(input);
        byte[] encBytes = EncryptBytes (bytes,desKey,desIV);
        return ByteArrayToHexString(encBytes);
      }
    
      public static string DecryptHexStrings(string encryptedOutput, byte[] desKey, byte[] desIV)
      {
        byte[] bytes = HexStringToByteArray(encryptedOutput);
        byte[] decBytes = DecryptBytes(bytes,desKey,desIV);
        return ByteArrayToHexString(decBytes);
      }
    
      public static string EncryptHexStrings(string input, string desKey, string desIV)
      {
        byte[] key = HexStringToByteArray(desKey);
        byte[] iv = HexStringToByteArray(desIV);
        return EncryptHexStrings(input, key, iv);
      }
    
      public static string DecryptHexStrings(string encryptedOutput, string desKey, string desIV)
      {
        byte[] key = HexStringToByteArray(desKey);
        byte[] iv = HexStringToByteArray(desIV);
        return DecryptHexStrings(encryptedOutput,key,iv);
      }
    
      public static byte[] HexStringToByteArray(string s)
      {
        byte[] ret = new byte[s.Length / 2];
        for (int i=0; i<s.Length; i+=2)
        {
          ret[i/2] = Convert.ToByte (s.Substring (i,2), 16);      
        }
        return ret;
      }
    
      public static string ByteArrayToHexString(byte[] bytes)
      {
        StringBuilder sb = new StringBuilder();
        foreach (byte b in bytes)
          sb.AppendFormat("{0:X2}", b);
        return sb.ToString();
      }
    
    }
