     /// <summary>
        /// Determines if the current application is 32 or 64-bit.
        /// se retorno == 32 = x86 else x64
        /// </summary>
        public int Bits()
        {
            return IntPtr.Size * 8;
        }
