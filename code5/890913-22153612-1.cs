        public class MyNotVerySecureCrypto
        {
          private byte[]   Key      { get ; set ; }
          private Encoding Encoding { get ; set ; }
          
          public MyNotVerySecureCrypto( string key , Encoding encoding )
          {
            this.Encoding = encoding ;
            this.Key      = Encoding.GetBytes(key).Where( b => b != 0 ).ToArray() ;
            return ;
          }
          public MyNotVerySecureCrypto( string key ) : this ( key , Encoding.UTF8 )
          {
            return ;
          }
          
          public string Encrypt( string plainText )
          {
            int i = 0 ;
            byte[] octets = Encoding
                            .GetBytes(plainText)
                            .Select( b => (byte) (b^Key[(++i)%Key.Length]) )
                            .ToArray()
                            ;
            string cipherText = Convert.ToBase64String(octets) ;
            return cipherText ;
          }
          
          public string Decrypt( string cipherText )
          {
            int i = 0 ;
            byte[] octets = Convert
                            .FromBase64String(cipherText)
                            .Select( b => (byte) (b^Key[(++i)%Key.Length]) )
                            .ToArray()
                            ;
            string plainText = Encoding.GetString( octets ) ;
            return plainText ;
          }
          
        }
