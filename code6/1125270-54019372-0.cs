    using Org.BouncyCastle.Crypto;  
    using Org.BouncyCastle.Security; 
    CipherKeyGenerator gen = new CipherKeyGenerator();
    gen = GeneratorUtilities.GetKeyGenerator("AES"); // using ASE algo
    byte[] k = gen.GenerateKey(); // 256 bit key
