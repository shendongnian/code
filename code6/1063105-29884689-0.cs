    public class KMSAlgorithm : SymmetricAlgorithm
    {
        private IAmazonKeyManagementService _client;
        private string _keyId;
    
        public KMSAlgorithm(IAmazonKeyManagementService client)
        {
            this._client = client;
        }
    
        public KMSAlgorithm(IAmazonKeyManagementService client, string keyId)
            : this(client)
        {
            this._keyId = keyId;
        }
    
        public override ICryptoTransform CreateDecryptor()
        {
            return new KMSCryptoTransform.Decryptor(_client);
        }
    
        public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
        {
            throw new NotImplementedException();
        }
    
        public override ICryptoTransform CreateEncryptor()
        {
            return new KMSCryptoTransform.Encryptor(_client, _keyId);
        }
    
        public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
        {
            throw new NotImplementedException();
        }
    
        public override void GenerateIV()
        {
            throw new NotImplementedException();
        }
    
        public override void GenerateKey()
        {
            throw new NotImplementedException();
        }
    }
    
    public abstract class KMSCryptoTransform : ICryptoTransform
    {
        protected IAmazonKeyManagementService _client;
        protected string _keyId;
    
        public KMSCryptoTransform(IAmazonKeyManagementService client)
        {
            this._client = client;
        }
    
        public KMSCryptoTransform(IAmazonKeyManagementService client, string keyId)
            : this(client)
        {
            this._keyId = keyId;
        }
    
        public bool CanReuseTransform
        {
            get { return true; }
        }
    
        public bool CanTransformMultipleBlocks
        {
            get { return false; }
        }
    
        public int InputBlockSize
        {
            get { throw new NotImplementedException(); }
        }
    
        public int OutputBlockSize
        {
            get { throw new NotImplementedException(); }
        }
    
        public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        {
            throw new NotImplementedException();
        }
    
        public abstract byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount);
    
        public void Dispose()
        {
    
        }
    
        public class Decryptor : KMSCryptoTransform
        {
            public Decryptor(IAmazonKeyManagementService client)
                : base(client) { }
    
            public override byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
            {
                return _client.Decrypt(new DecryptRequest()
                {
                    CiphertextBlob = new MemoryStream(inputBuffer, inputOffset, inputCount))
                }).Plaintext.ToArray();
            }
        }
    
        public class Encryptor : KMSCryptoTransform
        {
            public Encryptor(IAmazonKeyManagementService client, string keyId)
                : base(client, keyId) { }
    
            public override byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
            {
                return _client.Encrypt(new EncryptRequest()
                {
                    KeyId = _keyId,
                    Plaintext = MemoryStream(inputBuffer, inputOffset, inputCount))
                }).CiphertextBlob.ToArray();
            }
        }
    }
