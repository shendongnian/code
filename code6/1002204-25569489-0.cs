	public static class MyExtensions
    {
        public static System.Net.IPAddress Increment(this System.Net.IPAddress value)
        {
            var ip = BitConverter.ToInt32(value.GetAddressBytes().Reverse().ToArray(), 0);
            ip++;
            return new System.Net.IPAddress(BitConverter.GetBytes(ip).Reverse().ToArray());
        }
    }
