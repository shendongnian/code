    public class SampleRandomNumber
    {
        static readonly object Lock = new object();
        static readonly RNGCryptoServiceProvider Random = new RNGCryptoServiceProvider();
    
        public static int NextInt32()
        {
            lock (Lock)
            {
                var bytes = new byte[4];
                Random.GetBytes(bytes);
    
                return BitConverter.ToInt32(bytes, 0);
            }
        }
    }
