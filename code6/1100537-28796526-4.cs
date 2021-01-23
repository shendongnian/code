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
    
            private static byte[] bIV = 
            { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18,
            0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };
    
            private const string cryptoKey =
                "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";
    
            public static CryptoStream CreateEncryptionStream(byte[] key, byte[] iv, Stream outputStream)
            {
                Rijndael rijndael = new RijndaelManaged();
                rijndael.KeySize = 256;
    
                CryptoStream encryptor = new CryptoStream(
                    outputStream,
                    rijndael.CreateEncryptor(key, iv),
                    CryptoStreamMode.Write);
                return encryptor;
            }
    
            public static CryptoStream CreateDecryptionStream(byte[] key, byte[] iv, Stream inputStream)
            {
                Rijndael rijndael = new RijndaelManaged();
                rijndael.KeySize = 256;
    
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
                byte[] iv = bIV;
    
                using (FileStream file = new FileStream(Environment.CurrentDirectory + @"\class.dat", FileMode.Create))
                using (CryptoStream cryptoStream = CreateEncryptionStream(key, iv, file))
                {
                    WriteObjectToStream(cryptoStream, myVarClass);
                }
    
                MyClass newMyVarClass;
                using (FileStream file = new FileStream(Environment.CurrentDirectory + @"\class.dat", FileMode.Open))
                using (CryptoStream cryptoStream = CreateDecryptionStream(key, iv, file))
                {
                    newMyVarClass = (MyClass)ReadObjectFromStream(cryptoStream);
                }
    
                Console.WriteLine("newMyVarClass.SomeInt: {0}; newMyVarClass.TestValue: {1}",
                    newMyVarClass.SomeInt,
                    newMyVarClass.TestValue);
            }
        }
    }
