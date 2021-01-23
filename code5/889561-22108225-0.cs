    public static class StringTest
    {
        public static unsafe void Burn(this string input)
        {
            fixed (char* c = input)
            {
                Marshal.Copy(new string('\0', input.Length).ToCharArray(), 0, new IntPtr(c), input.Length);
            }
        }
    }
