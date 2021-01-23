    using System.Security.Cryptography;
    
    var rng = RandomNumberGenerator.Create();
    //bytes to hold number
    var bytes = new byte[8];
    //randomize
    rng.GetNonZeroBytes(bytes);
    //Convert
    long random = BitConverter.ToInt64(bytes, 0);
