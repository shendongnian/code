    public class BCEngine
        {
            private Encoding _encoding;
            private IBlockCipher _blockCipher;
            private PaddedBufferedBlockCipher _cipher;
            private IBlockCipherPadding _padding;
    
            Pkcs7Padding pkcs = new Pkcs7Padding();
    
            public BCEngine(IBlockCipher blockCipher, Encoding encoding)
            {
                _blockCipher = blockCipher;
                _encoding = encoding;
            }
    
            public string Encrypt(string plain, string key)
            {
                byte[] result = BouncyCastleCrypto(true, _encoding.GetBytes(plain), key);
                return Convert.ToBase64String(result);
            }
    
            public string Decrypt(string cipher, string key)
            {
                byte[] result = BouncyCastleCrypto(false, Convert.FromBase64String(cipher), key);
                return _encoding.GetString(result, 0, result.Length);
            }
    
            private byte[] BouncyCastleCrypto(bool forEncrypt, byte[] input, string key)
            {
                try
                {                                                                                   
                    _cipher = _padding == null ? new PaddedBufferedBlockCipher(_blockCipher) : new PaddedBufferedBlockCipher(_blockCipher, _padding);
                    byte[] keyByte = _encoding.GetBytes(key);
                    _cipher.Init(forEncrypt, new KeyParameter(keyByte));
                    return _cipher.DoFinal(input);
                }
                catch (Org.BouncyCastle.Crypto.CryptoException ex)
                {
                    throw new CryptoException(ex.Message);
                }
            }
    
            public string AESEncryption(string plain, string key)
            {
               
                return Encrypt(plain, key);
            }
    
            public string AESDecryption(string cipher, string key)
            {
                return Decrypt(cipher, key);
            }
    
            public BCEngine()
            {
                _blockCipher = new AesEngine();
                _encoding = Encoding.UTF8;
                pkcs = new Pkcs7Padding();
                _padding = pkcs;
            }
        }
