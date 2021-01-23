    public static class MyExtensions
    {
        /// <summary>
        /// Sets an individual bit inside a byte, based on the bit number.
        /// </summary>
        /// <param name="aByte">The byte where a bit is to be changed.</param>
        /// <param name="bitNumber">The bit number to read (between 0 and 7).</param>
        /// <param name="value">The value to set the bit to.  0/False or 1/True.</param>
        /// <returns>A byte with the requested bit changed.</returns>
        /// <remarks>The bit number must be between 0 and 7, otherwise an ArgumentOutOfRangeException is thrown.</remarks>
        public static byte SetBit(this byte aByte, byte bitNumber, bool value)
        {
            if (bitNumber > 7) { throw new ArgumentOutOfRangeException("bitNumber", "bitNumber was > 7"); }
            // create a mask of zeros except for the bit we want to modify
            byte mask = 1;
            mask = (byte)(mask << bitNumber);
            if (value)
            {
                // use bitwise-inclusive-or operator to make sure the bit equals 1 (and nothing else is changed)
                aByte = (byte)(aByte | mask);
            }
            else
            {
                // grab the inverse of our original mask (all ones except our bit equals zero)
                mask = (byte)(byte.MaxValue - mask);
                // use bitwise-and operator to make sure our bit equals 0 (and nothing else is changed)
                aByte = (byte)(aByte & mask);
            }
            return aByte;
        }
        /// <summary>
        /// Returns the value of an individual bit from within a byte.
        /// </summary>
        /// <param name="aByte">The byte from which to return bit data.</param>
        /// <param name="bitNumber">The bit number to read (between 0 and 7).</param>
        /// <returns>The value inside the requested bit.  0/False or 1/True.</returns>
        /// <remarks>The bit number must be between 0 and 7, otherwise an ArgumentOutOfRangeException is thrown.</remarks>
        public static bool GetBit(this byte aByte, byte bitNumber)
        {
            if (bitNumber > 7) { throw new ArgumentOutOfRangeException("bitNumber", "bitNumber was > 7"); }
            // create a mask of zeros except for the bit we want to modify
            byte mask = 1;
            mask = (byte)(mask << bitNumber);
            // use bitwise-and operator with our mask; if we get a 1, our bit must have also been a 1
            return (aByte & mask) > 0;
        }
    }   
