    class Program
    {
        [DllImport("FixedSizeString", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern void fillBytes(IntPtr buffer, int nbBytes);
        void main(string[] args)
        {
            int BUFFSIZ = 256;// corresponds to the number of bytes in the buffer
            IntPtr iptr = Marshal.AllocHGlobal(BUFFSIZ);
            byte[] buffer = new byte[BUFFSIZ];
            if (iptr == IntPtr.Zero)
                Console.WriteLine("Allocation failed");
            else
            {
                fillBytes(iptr, BUFFSIZ);
                for (int i = 0; i < BUFFSIZ; ++i)
                {
                    buffer[i] = Marshal.ReadByte(buffer, i);
                }
                Marshal.FreeHGlobal(iptr);
                // now deal with buffer here ...
            }
        }
    }
