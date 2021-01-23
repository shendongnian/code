    internal static class Password
    {
        public static void Configure(IPrivateKeyProvider keyProvider)
        {
            keyProvider = keyProvider;
        }
        public static byte Generate(byte passwordPublicKey); // use keyProvider
        private static IPrivateKeyProvider* keyProvider;
    }
    internal interface IPrivateKeyProvider
    {
        byte GetPrivateKey();
    }
    internal class ConfigPrivateKeyProvider : IPrivateKeyProvider
    {
        private static readonly byte PASSWORD_PRIVATE_KEY
             = ConfigFile.ReadByte("PASSWORD_PRIVATE_KEY");
        public byte GetPrivateKey()
        {
            return PASSWORD_PRIVATE_KEY;
        }
    }
    internal class PrivateKeyProviderMock : IPrivateKeyProvider
    {
        public PrivateKeyProviderMock(byte privateKey)
        {
            this.privateKey = privateKey;
        }
        public byte GetPrivateKey()
        {
            return this.privateKey;
        }
    }
