    using System;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    
    class XORCryptoTransform : ICryptoTransform
    {
        uint previous;
        bool encrypting;
    
        public XORCryptoTransform(uint iv, bool encrypting)
        {
            previous = iv;
            this.encrypting = encrypting;
        }
    
        public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        {
            for (int i = 0; i < inputCount; i+=4)
            {
                uint block = BitConverter.ToUInt32(inputBuffer, inputOffset + i);
                byte[] transformed = BitConverter.GetBytes(block ^ previous);
                Array.Copy(transformed, 0, outputBuffer, outputOffset + i, transformed.Length);
    
                if (encrypting)
                {
                    previous = block;
                }
                else
                {
                    previous = BitConverter.ToUInt32(transformed, 0);
                }
            }
                
            return inputCount;
        }
    
        public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
        {
            var transformed = new byte[inputCount];
            TransformBlock(inputBuffer, inputOffset, inputCount, transformed, 0);
            return transformed;
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
            // 4 bytes in uint
            get { return 4; }
        }
    
        public int OutputBlockSize
        {
            get { return 4; }
        }
    
        public void Dispose()
        {
        }
    }
    
    class Program
    {
        static void Main()
        {
            uint iv = 0; // first block will not be changed
            byte[] plaintext = Guid.NewGuid().ToByteArray();
            byte[] ciphertext;
            using (var memoryStream = new MemoryStream())
            using (var encryptStream = new CryptoStream(
                    memoryStream,
                    new XORCryptoTransform(iv, true),
                    CryptoStreamMode.Write))
            {
                encryptStream.Write(plaintext, 0, plaintext.Length);
                ciphertext = memoryStream.ToArray();
            }
    
            byte[] decrypted = new byte[ciphertext.Length];
    
            using (var memoryStream = new MemoryStream(ciphertext))
            using (var encryptStream = new CryptoStream(
                    memoryStream,
                    new XORCryptoTransform(iv, false),
                    CryptoStreamMode.Read))
            {
                encryptStream.Read(decrypted, 0, decrypted.Length);
            }
    
            bool matched = plaintext.SequenceEqual(decrypted);
            Console.WriteLine("Matched: {0}", matched);
        }
    }
