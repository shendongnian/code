                        // This structure is as the header for the CngKey
                        // all should be byte arrays in Big-Endian order
                        //typedef struct _BCRYPT_RSAKEY_BLOB {
                        //  ULONG Magic; 
                        //  ULONG BitLength; 
                        //  ULONG cbPublicExp;
                        //  ULONG cbModulus;
                        //  ULONG cbPrime1;  private key only
                        //  ULONG cbPrime2;  private key only
                        //} BCRYPT_RSAKEY_BLOB;
                        // This is the actual Key Data that is attached to the header
                        //BCRYPT_RSAKEY_BLOB
                        //  PublicExponent[cbPublicExp] 
                        //  Modulus[cbModulus]
                        //first get the public key from the cert (modulus and exponent)
						// not shown
                        byte[] publicExponent = <your public key exponent>; //Typically equal to from what I've found: {0x01, 0x00, 0x01}
                        byte[] btMod = <your public key modulus>;  //for 128 bytes for 1024 bit key, and 256 bytes for 2048 keys
                        //BCRYPT_RSAPUBLIC_MAGIC = 0x31415352,
                        // flip to big-endian
                        byte[] Magic = new byte[] { 0x52, 0x53, 0x41, 0x31}; 
                        // for BitLendth: convert the length of the key's Modulus as a byte array into bits,
                        // so the size of the key, in bits should be btMod.Length * 8. Convert to a DWord, then flip for Big-Endian 
                        // example 128 bytes = 1024 bits = 0x00000400 = {0x00, 0x00, 0x04, 0x00} = flipped {0x00, 0x04, 0x00, 0x00}
                        // example 256 bytes = 2048 bits = 0x00000800 = {0x00, 0x00, 0x08, 0x00} = flipped {0x00, 0x08, 0x00, 0x00}
                        string sHex = (btMod.Length * 8).ToString("X8");
                        byte[] BitLength = Util.ConvertHexStringToByteArray(sHex);
                        Array.Reverse(BitLength); //flip to Big-Endian
                        
                        // same thing for exponent length (in bytes)
                        sHex = (publicExponent.Length).ToString("X8");
                        byte[] cbPublicExp = Util.ConvertHexStringToByteArray(sHex);
                        Array.Reverse(cbPublicExp);
                        // same thing for modulus length (in bytes)
                        sHex = (btMod.Length).ToString("X8");
                        byte[] cbModulus = Util.ConvertHexStringToByteArray(sHex);
                        Array.Reverse(cbModulus);                      
                        
                        // add the 0 bytes for cbPrime1 and cbPrime2 (always zeros for public keys, these are used for private keys, but need to be zero here)
						// just make one array with both 4 byte primes as zeros
                        byte[] cbPrimes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
                        //combine all the parts together into the one big byte array in the order the structure
                        var keyImport = Magic.Concat(BitLength).Concat(cbPublicExp).Concat(cbModulus).Concat(cbPrimes).Concat(publicExponent).Concat(btMod).ToArray();
                        var cngKey = CngKey.Import(keyImport, CngKeyBlobFormat.GenericPublicBlob);
                        
                        // pass the key to the class constructor
                        RSACng rsa = new RSACng(cngKey);
						
                        //verify: our randomly generated M (message) used to create the signature (not shown), the signature, enum for SHA256, padding
                        verified = rsa.VerifyData(M, signature, HashAlgorithmName.SHA256,RSASignaturePadding.Pkcs1);
