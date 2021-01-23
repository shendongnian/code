    public static class Ieee754
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct Int32SingleConverter
        {
            [FieldOffset(0)]
            public int Int32;
            [FieldOffset(0)]
            public float Single;
        }
        public static float NextSingle(float value)
        {
            int bits = new Int32SingleConverter { Single = value }.Int32;
            if (bits >= 0)
            {
                bits++;
            }
            else if (bits != int.MinValue)
            {
                bits--;
            }
            else
            {
                bits = 0;
            }
            return new Int32SingleConverter { Int32 = bits }.Single;
        }
    }
