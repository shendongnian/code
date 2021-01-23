    using System.Security.Cryptography;
    ...
    class AES {
       private AesCryptoServiceProvider aes;
       public AES (Byte[] IV, Byte[] Key) {
           aes = AesCryptoServiceProvider();
           aes.Key = Key; // 256 Bits Long
           // AES Key can be generated using SHA256
           aes.IV = IV; // 128 Bits Long
           // IV can be generated using MD5
       }
       public Byte[] Encrypt(Byte[] FileStream) {
           ICryptoTransform Transform = aes.CreateEncryptor();
           return Transform.TransformFinalBlock(FileStream, 0, FileStream.Lenght);
       }     
       public Byte[] Decrypt (Byte[] FileStream){
           ICryptoTransform Transform = aes.CreateDecryptor();
           return Transform.TransformFinalBlock(FileStream, 0, FileStream.Lenght);
      }
    }
