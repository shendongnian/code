    using Org.BouncyCastle.Crypto;  
    using Org.BouncyCastle.Security; 
    CipherKeyGenerator gen = new CipherKeyGenerator();
    gen = GeneratorUtilities.GetKeyGenerator("AES256"); // using AES
    byte[] k = gen.GenerateKey(); // 256 bit key
