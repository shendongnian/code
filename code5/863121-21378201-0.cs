        private System.Security.Cryptography.SymmetricAlgorithm GetAesKey()
        {
            byte[] symKey = RandomNextBytes();
            var aes = System.Security.Cryptography.SymmetricAlgorithm.Create();
            aes.Key = symKey;
            aes.IV = symKey;
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            return aes;
         }
