    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    
    namespace iOSEncryption
    {
        /// <summary>
        /// Represents a simple interface for Symmetric Criptography using Rijndael algorithm 
        /// </summary>
        public class CryptoRijndael
        {
            public static Byte[] DefaultSalt
            {
                get
                {
                    return defaultSalt;
                }
            }
            private static Byte[] defaultSalt = new Byte[24] 
            { 
                0x6d, 0x61, 0x79, 0x74, 0x68, 0x65, 0x66, 0x6f, 
                0x72, 0x63, 0x65, 0x62, 0x65, 0x77, 0x69, 0x74, 
                0x68, 0x79, 0x6f, 0x75, 0x4a, 0x65, 0x64, 0x69 
            };
    
            private static Byte[] GetRandomArray(Int32 length)
            {
                Byte[] retVal = new Byte[length];
                Random rd = new Random();
    
                for (int i = 0; i < length; i++)
                {
                    retVal[i] = (Byte)rd.Next(0x0, 0xFF);
                }
    
                System.Threading.Thread.Sleep(150);
                return retVal;
    
            }
    
            /// <summary>
            /// Represents an array of Bytes to derives Private Key and IV
            /// </summary>
            public class Salt
            {
                private Byte[] _Value = null;
                public Byte[] Value
                {
                    get
                    {
                        return _Value;
                    }
                }
    
                public Salt()
                    : this(defaultSalt)
                {
    
                }
                public Salt(Byte[] value)
                {
                    if (value.Length < 16)
                    {
                        throw new InvalidSaltLengthException();
                    }
                    else
                    {
                        _Value = value;
                    }
                }
    
                public class InvalidSaltLengthException : Exception
                {
                    public InvalidSaltLengthException()
                        : base("Bytes array must contains at least 16 elements")
                    {
    
                    }
                }
            }
    
            /// <summary>
            /// Represents an array of 32 bytes. 
            /// A consistent 256 bits private Key
            /// </summary>
            public class PrivateKey
            {
                private Byte[] _Value = null;
                public Byte[] Value
                {
                    get
                    {
                        return _Value;
                    }
                }
    
                public PrivateKey()
                    : this(GetRandomArray(32))
                {
    
                }
                public PrivateKey(Byte[] value)
                {
                    if (value.Length != 32)
                    {
                        throw new InvalidPrivateKeyLengthException();
                    }
                    else
                    {
                        _Value = value;
                    }
                }
    
                public class InvalidPrivateKeyLengthException : Exception
                {
                    public InvalidPrivateKeyLengthException()
                        : base("Bytes array must contains 32 elements")
                    {
    
                    }
                }
    
                public class InvalidPrivateKeyException : Exception
                {
                    public InvalidPrivateKeyException()
                        : base("Private key must be valid and not null")
                    {
    
                    }
                }
            }
    
            /// <summary>
            /// Represents the initializion vector for the simmetric algorithm
            /// </summary>
            public class InitVector
            {
                private Byte[] _Value = null;
                public Byte[] Value
                {
                    get
                    {
                        return _Value;
                    }
                }
    
                public InitVector()
                    : this(GetRandomArray(16))
                {
    
                }
                public InitVector(Byte[] value)
                {
                    if (value.Length != 16)
                    {
                        throw new InvalidIVLengthException();
                    }
                    else
                    {
                        _Value = value;
                    }
                }
    
                public class InvalidIVLengthException : Exception
                {
                    public InvalidIVLengthException()
                        : base("Bytes array must contains 16 elements")
                    {
    
                    }
                }
            }
    
            public class DecryptException : Exception
            {
                public DecryptException(Exception innerException) :
                    base("Decrypt error occurred check for Password, PrivateKey, IV or Salt", innerException)
                {
    
                }
            }
            public class EncryptException : Exception
            {
                public EncryptException(Exception innerException) :
                    base("Encrypt error occurred", innerException)
                {
    
                }
            }
    
            /// <summary>
            /// Gets the 256 bits private Key for the simmetric algorithm
            /// </summary>
            public PrivateKey ActivePrivateKey { get; private set; }
            /// <summary>
            /// Gets the current array of Bytes for derives Key and IV from a given password
            /// </summary>
            public Salt ActiveSalt { get; private set; }
            /// <summary>
            /// Gets the current IV for the simmetric algorithm
            /// </summary>
            public InitVector ActiveIV { get; private set; }
    
    
            private Encoding _StringEncodingType = Encoding.GetEncoding(1252);
            /// <summary>
            /// Gets or Sets the EncodingType. Default is 1252
            /// </summary>
            public Encoding StringEncodingType
            {
                get
                {
                    return _StringEncodingType;
                }
                set
                {
                    _StringEncodingType = value;
                }
            }
    
            /// <summary>
            /// Initializes a new istance of the CryptoRijndael class.\r\n
            /// Creates randoms privateKey and IV.
            /// </summary>
            public CryptoRijndael()
            {
                ActivePrivateKey = new PrivateKey();
                ActiveIV = new InitVector();
            }
            /// <summary>
            /// Initializes a new istance of the CryptoRijndael class.\r\n
            /// privateKey must be Byte[32] and initVector must be Byte[16]
            /// </summary>
            /// <param name="privateKey"></param>
            /// <param name="initVector"></param>
            public CryptoRijndael(Byte[] privateKey, Byte[] initVector)
            {
                ActivePrivateKey = new PrivateKey(privateKey);
                ActiveIV = new InitVector(initVector);
            }
            /// <summary>
            /// Initializes a new istance of the CryptoRijndael class.\r\n
            /// Derives 256bits private Key from password and IV from iVString using Byte[24] default Salt
            /// </summary>
            /// <param name="password"></param>
            public CryptoRijndael(String password, String iVString)
            {
                ActiveSalt = new Salt(defaultSalt);
                Rfc2898DeriveBytes dbKey = new Rfc2898DeriveBytes(password, ActiveSalt.Value);
                Rfc2898DeriveBytes dbIV = new Rfc2898DeriveBytes(iVString, ActiveSalt.Value);
                ActivePrivateKey = new PrivateKey(dbKey.GetBytes(32));
                ActiveIV = new InitVector(dbIV.GetBytes(16));
            }
            /// <summary>
            /// Initializes a new istance of the CryptoRijndael class.\r\n
            /// Derives 256bits private Key and IV form password using Byte[24] default Salt
            /// </summary>
            /// <param name="password"></param>
            public CryptoRijndael(String password)
                : this(password, defaultSalt)
            {
    
            }
            /// <summary>
            /// Initializes a new istance of the CryptoRijndael class.\r\n
            /// Derives 256bits private Key and IV form password using custom Salt
            /// </summary>
            /// <param name="password"></param>
            /// <param name="salt"></param>
            public CryptoRijndael(String password, Byte[] salt)
            {
                ActiveSalt = new Salt(salt);
                Rfc2898DeriveBytes db = new Rfc2898DeriveBytes(password, ActiveSalt.Value);
                ActivePrivateKey = new PrivateKey(db.GetBytes(32));
                ActiveIV = new InitVector(db.GetBytes(16));
            }
    
            public void Encrypt(Stream clearData, Stream encryptedData)
            {
                EncryptException ee = null;
                if (ActivePrivateKey == null)
                {
                    throw new PrivateKey.InvalidPrivateKeyException();
                }
                else
                {
                    Rijndael alg = null;
                    CryptoStream cs = null;
                    try
                    {
                        alg = Rijndael.Create();
    
    
                        alg.Key = ActivePrivateKey.Value;
                        alg.IV = ActiveIV.Value;
    
                        cs = new CryptoStream(encryptedData, alg.CreateEncryptor(), CryptoStreamMode.Write);
    
                        clearData.CopyTo(cs);
    
                        cs.Close();
    
                    }
                    catch (Exception ex)
                    {
                        ee = new EncryptException(ex);
                    }
                    finally
                    {
                        if (cs != null)
                        {
                            cs.Dispose();
                            GC.SuppressFinalize(cs);
                            cs = null;
                        }
    
                        if (alg != null)
                        {
                            alg.Dispose();
                            GC.SuppressFinalize(alg);
                            alg = null;
                        }
                    }
    
                }
    
                if (ee != null)
                {
                    throw ee;
                }
            }
    
            public void Decrypt(Stream clearData, Stream encryptedData)
            {
    
                DecryptException de = null;
                if (ActivePrivateKey == null)
                {
                    throw new PrivateKey.InvalidPrivateKeyException();
                }
                else
                {
                    Rijndael alg = null;
                    CryptoStream cs = null;
                    try
                    {
                        alg = Rijndael.Create();
    
    
                        alg.Key = ActivePrivateKey.Value;
                        alg.IV = ActiveIV.Value;
    
                        cs = new CryptoStream(clearData, alg.CreateDecryptor(), CryptoStreamMode.Write);
                        encryptedData.CopyTo(cs);
                        cs.Close();
    
                    }
                    catch (Exception ex)
                    {
                        de = new DecryptException(ex);
                    }
                    finally
                    {
                        if (cs != null)
                        {
                            cs.Dispose();
                            GC.SuppressFinalize(cs);
                            cs = null;
                        }
    
                        if (alg != null)
                        {
                            alg.Dispose();
                            GC.SuppressFinalize(alg);
                            alg = null;
                        }
                    }
    
                }
    
                if (de != null)
                {
                    throw de;
                }
            }
    
            public Byte[] Encrypt(Byte[] clearData)
            {
                Byte[] encryptedData = null;
                MemoryStream encms = new MemoryStream();
                MemoryStream clms = new MemoryStream(clearData);
    
                Encrypt(clms, encms);
    
                encryptedData = encms.ToArray();
    
                encms.Close();
                encms.Dispose();
                GC.SuppressFinalize(encms);
                encms = null;
    
                clms.Close();
                clms.Dispose();
                GC.SuppressFinalize(clms);
                clms = null;
    
                return encryptedData;
            }
    
            public Byte[] Decrypt(Byte[] encryptedData)
            {
                Byte[] clearData = null;
                MemoryStream encms = new MemoryStream(encryptedData);
                MemoryStream clms = new MemoryStream();
    
                Decrypt(clms, encms);
    
                clearData = clms.ToArray();
    
                encms.Close();
                encms.Dispose();
                GC.SuppressFinalize(encms);
                encms = null;
    
                clms.Close();
                clms.Dispose();
                GC.SuppressFinalize(clms);
                clms = null;
    
                return clearData;
            }
    
            public String Encrypt(String clearData)
            {
                return Convert.ToBase64String(Encrypt(StringEncodingType.GetBytes(clearData)));
            }
    
            public String Decrypt(String encryptedData)
            {
                return StringEncodingType.GetString(Decrypt(Convert.FromBase64String(encryptedData)));
            }
    
    
        }
    }
    
    
