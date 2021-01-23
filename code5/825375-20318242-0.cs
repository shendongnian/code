    class DeterministicRandomGenerator : System.Security.Cryptography.RandomNumberGenerator
    {
        Random r = new Random(0);
        public override void GetBytes(byte[] data)
        {
            r.NextBytes(data);
        }
        public override void GetNonZeroBytes(byte[] data)
        {
            // simple implementation
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)r.Next(1, 256);
        }
    }
