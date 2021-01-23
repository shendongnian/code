    public class AesManagedCtr : Aes
    {
        private AesManaged Aes;
        public AesManagedCtr()
        {
            Aes = new AesManaged();
            Aes.Mode = CipherMode.ECB;
            Aes.Padding = PaddingMode.None;
        }
        public override byte[] IV
        {
            get
            {
                return Aes.IV;
            }
            set
            {
                Aes.IV = value;
            }
        }
        public override byte[] Key
        {
            get
            {
                return Aes.Key;
            }
            set
            {
                Aes.Key = value;
            }
        }
        public override int KeySize
        {
            get
            {
                return Aes.KeySize;
            }
            set
            {
                Aes.KeySize = value;
            }
        }
        public override CipherMode Mode
        {
            get
            {
                return Aes.Mode;
            }
            set
            {
                if (value != CipherMode.ECB)
                {
                    throw new CryptographicException();
                }
            }
        }
        public override PaddingMode Padding
        {
            get
            {
                return Aes.Padding;
            }
            set
            {
                if (value != PaddingMode.None)
                {
                    throw new CryptographicException();
                }
            }
        }
        public override int BlockSize
        {
            get
            {
                return 8;
            }
            set
            {
                if (value != 8)
                {
                    throw new CryptographicException();
                }
            }
        }
        public override KeySizes[] LegalBlockSizes
        {
            get
            {
                return new[] { new KeySizes(BlockSize, BlockSize, 0) };
            }
        }
        public override int FeedbackSize
        {
            get
            {
                return Aes.FeedbackSize;
            }
            set
            {
                if (FeedbackSize != Aes.FeedbackSize)
                {
                    throw new CryptographicException();
                }
            }
        }
        public override ICryptoTransform CreateDecryptor()
        {
            // Note that we always use the Aes.CreateEncryptor, even for
            // decrypting, because we only have to "rebuild" the encrypted
            // CTR nonce.
            return CreateEncryptor();
        }
        public override ICryptoTransform CreateDecryptor(byte[] key, byte[] iv)
        {
            // Note that we always use the Aes.CreateEncryptor, even for
            // decrypting, because we only have to "rebuild" the encrypted
            // CTR nonce.
            return CreateEncryptor(key, iv);
        }
        public override ICryptoTransform CreateEncryptor()
        {
            return new StreamCipher(Aes.CreateEncryptor(), IV);
        }
        public override ICryptoTransform CreateEncryptor(byte[] key, byte[] iv)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            if (!ValidKeySize(key.Length * 8))
            {
                throw new ArgumentException("key");
            }
            if (iv == null)
            {
                throw new ArgumentNullException("iv");
            }
            if (iv.Length * 8 != BlockSizeValue)
            {
                throw new ArgumentException("iv");
            }
            return new StreamCipher(Aes.CreateEncryptor(key, iv), iv);
        }
        public override void GenerateIV()
        {
            Aes.GenerateIV();
        }
        public override void GenerateKey()
        {
            Aes.GenerateKey();
        }
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    Aes.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
        protected sealed class StreamCipher : ICryptoTransform
        {
            private ICryptoTransform Transform;
            private byte[] IV;
            private byte[] EncryptedIV = new byte[16];
            private int EncryptedIVOffset = 0;
            public StreamCipher(ICryptoTransform transform, byte[] iv)
            {
                Transform = transform;
                // Note that in this implementation the IV/Nonce and the 
                // Counter described by http://en.wikipedia.org/wiki/Block_cipher_mode_of_operation#Counter_.28CTR.29
                // are additioned together in a single IV, that then is
                // incremented by 1 in a "big-endian" mode.
                IV = (byte[])iv.Clone();
                Transform.TransformBlock(IV, 0, IV.Length, EncryptedIV, 0);
            }
            public bool CanReuseTransform
            {
                get { return true; }
            }
            public bool CanTransformMultipleBlocks
            {
                get { return true; }
            }
            public int InputBlockSize
            {
                get { return 1; }
            }
            public int OutputBlockSize
            {
                get { return 1; }
            }
            public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
            {
                int count = Math.Min(inputCount, outputBuffer.Length - outputOffset);
                for (int i = 0; i < count; i++)
                {
                    if (EncryptedIVOffset == EncryptedIV.Length)
                    {
                        IncrementNonceAndResetOffset();
                    }
                    outputBuffer[outputOffset + i] = (byte)(inputBuffer[inputOffset + i] ^ EncryptedIV[EncryptedIVOffset]);
                    EncryptedIVOffset++;
                }
                return count;
            }
            public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
            {
                // This method can be reused. There is no "final block" in
                // CTR mode, because characters are encrypted one by one
                byte[] outputBuffer = new byte[inputCount];
                TransformBlock(inputBuffer, inputOffset, inputCount, outputBuffer, 0);
                return outputBuffer;
            }
            public void Dispose()
            {
                if (Transform != null)
                {
                    Transform.Dispose();
                    Transform = null;
                    IV = null;
                    EncryptedIV = null;
                }
                GC.SuppressFinalize(this);
            }
            private void IncrementNonceAndResetOffset()
            {
                int i = IV.Length - 1;
                do
                {
                    unchecked
                    {
                        IV[i]++;
                    }
                    if (IV[i] != 0 || i == 0)
                    {
                        break;
                    }
                    i--;
                }
                while (true);
                Transform.TransformBlock(IV, 0, IV.Length, EncryptedIV, 0);
                EncryptedIVOffset = 0;
            }
        }
        // A simple string-to-byte[] converter
        private static byte[] GetBytes(string str)
        {
            if (str.Length % 2 != 0)
            {
                throw new ArgumentException();
            }
            byte[] bytes = new byte[str.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = byte.Parse(str.Substring(i * 2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }
            return bytes;
        }
        public static void Test()
        {
            // Taken from http://csrc.nist.gov/publications/nistpubs/800-38a/sp800-38a.pdf
            // F.5.1 CTR-AES128.Encrypt
            // F.5.2 CTR-AES128.Decrypt 
            // F.5.3 CTR-AES192.Encrypt 
            // F.5.4 CTR-AES192.Decrypt 
            // F.5.5 CTR-AES256.Encrypt
            // F.5.6 CTR-AES256.Decrypt  
            string[] keys = new[]
            {
                // 128 bits
                "2b7e151628aed2a6abf7158809cf4f3c",
                // 192 bits
                "8e73b0f7da0e6452c810f32b809079e562f8ead2522c6b7b",
                // 256 bits
                "603deb1015ca71be2b73aef0857d77811f352c073b6108d72d9810a30914dff4",
            };
            string iv = "f0f1f2f3f4f5f6f7f8f9fafbfcfdfeff";
            string[] plains = new[]
            {
                "6bc1bee22e409f96e93d7e117393172a",
                "ae2d8a571e03ac9c9eb76fac45af8e51",
                "30c81c46a35ce411e5fbc1191a0a52ef",
                "f69f2445df4f9b17ad2b417be66c3710",
            };
            string[][] encrypteds = new[]
            {
                // 128 bits
                new[]
                {
                    "874d6191b620e3261bef6864990db6ce",
                    "9806f66b7970fdff8617187bb9fffdff",
                    "5ae4df3edbd5d35e5b4f09020db03eab",
                    "1e031dda2fbe03d1792170a0f3009cee",
                },
                // 192 bits
                new[]
                {
                    "1abc932417521ca24f2b0459fe7e6e0b",
                    "090339ec0aa6faefd5ccc2c6f4ce8e94",
                    "1e36b26bd1ebc670d1bd1d665620abf7",
                    "4f78a7f6d29809585a97daec58c6b050",
                },
                // 256 bits
                new[]
                {
                    "601ec313775789a5b7a7f504bbf3d228",
                    "f443e3ca4d62b59aca84e990cacaf5c5",
                    "2b0930daa23de94ce87017ba2d84988d",
                    "dfc9c58db67aada613c2dd08457941a6",
                },
            };
            for (int i = 0; i < keys.Length; i++)
            {
                var aes = new AesManagedCtr();
                aes.Key = GetBytes(keys[i]);
                aes.IV = GetBytes(iv);
                Console.WriteLine("{0} bits", aes.KeySize);
                {
                    Console.WriteLine("Encrypt");
                    ICryptoTransform encryptor = aes.CreateEncryptor();
                    var cipher = new byte[16];
                    for (int j = 0; j < plains.Length; j++)
                    {
                        byte[] plain = GetBytes(plains[j]);
                        encryptor.TransformBlock(plain, 0, plain.Length, cipher, 0);
                        string cipherHex = BitConverter.ToString(cipher).Replace("-", string.Empty).ToLowerInvariant();
                        if (cipherHex != encrypteds[i][j])
                        {
                            throw new Exception("Error encrypting " + j);
                        }
                        Console.WriteLine(cipherHex);
                    }
                }
                Console.WriteLine();
                {
                    Console.WriteLine("Decrypt");
                    ICryptoTransform decryptor = aes.CreateDecryptor();
                    var plain = new byte[16];
                    for (int j = 0; j < encrypteds[i].Length; j++)
                    {
                        byte[] encrypted = GetBytes(encrypteds[i][j]);
                        decryptor.TransformBlock(encrypted, 0, encrypted.Length, plain, 0);
                        string plainHex = BitConverter.ToString(plain).Replace("-", string.Empty).ToLowerInvariant();
                        if (plainHex != plains[j])
                        {
                            throw new Exception("Error decrypting " + j);
                        }
                        Console.WriteLine(plainHex);
                    }
                }
                Console.WriteLine();
            }
        }
    }
