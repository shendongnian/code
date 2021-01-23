    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security.Cryptography;
    
    namespace CryptoStreams
    {
        class Program
        {
            [Serializable]
            public class MyClass
            {
                public string TestValue
                {
                    get;
                    set;
                }
    
                public int SomeInt
                {
                    get;
                    set;
                }
            }
    
            public static void WriteObjectToStream(Stream outputStream, Object obj)
            {
                if (object.ReferenceEquals(null, obj))
                {
                    return;
                }
    
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(outputStream, obj);
            }
    
            public static object ReadObjectFromStream(Stream inputStream)
            {
                BinaryFormatter binForm = new BinaryFormatter();
                object obj = binForm.Deserialize(inputStream);
                return obj;
            }
    
            private const string cryptoKey =
                "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";
            private const int keySize = 256;
            private const int ivSize = 16; // block size is 128-bit
    
            public static CryptoStream CreateEncryptionStream(byte[] key, Stream outputStream)
            {
                byte[] iv = new byte[ivSize];
    
                using (var rng = new RNGCryptoServiceProvider())
                {
                    // Using a cryptographic random number generator
                    rng.GetNonZeroBytes(iv);
                }
    
                // Write IV to the start of the stream
                outputStream.Write(iv, 0, iv.Length);
    
                Rijndael rijndael = new RijndaelManaged();
                rijndael.KeySize = keySize;
    
                CryptoStream encryptor = new CryptoStream(
                    outputStream,
                    rijndael.CreateEncryptor(key, iv),
                    CryptoStreamMode.Write);
                return encryptor;
            }
    
            public static CryptoStream CreateDecryptionStream(byte[] key, Stream inputStream)
            {
                byte[] iv = new byte[ivSize];
    
                if (inputStream.Read(iv, 0, iv.Length) != iv.Length)
                {
                    throw new ApplicationException("Failed to load IV from file.");
                }
    
                Rijndael rijndael = new RijndaelManaged();
                rijndael.KeySize = keySize;
    
                CryptoStream decryptor = new CryptoStream(
                    inputStream,
                    rijndael.CreateDecryptor(key, iv),
                    CryptoStreamMode.Read);
                return decryptor;
            }
    
            static void Main(string[] args)
            {
                MyClass myVarClass = new MyClass
                {
                    SomeInt = 1234,
                    TestValue = "Hello"
                };
    
                byte[] key = Convert.FromBase64String(cryptoKey);
    
                using (FileStream file = new FileStream(Environment.CurrentDirectory + @"\class.dat", FileMode.Create))
                {
                    using (CryptoStream cryptoStream = CreateEncryptionStream(key, file))
                    {
                        WriteObjectToStream(cryptoStream, myVarClass);
                    }
                }
    
                MyClass newMyVarClass;
                using (FileStream file = new FileStream(Environment.CurrentDirectory + @"\class.dat", FileMode.Open))
                using (CryptoStream cryptoStream = CreateDecryptionStream(key, file))
                {
                    newMyVarClass = (MyClass)ReadObjectFromStream(cryptoStream);
                }
    
                Console.WriteLine("newMyVarClass.SomeInt: {0}; newMyVarClass.TestValue: {1}",
                    newMyVarClass.SomeInt,
                    newMyVarClass.TestValue);
            }
        }
    }
