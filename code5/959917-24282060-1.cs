    /// <summary>
    /// Convert an Int32 value into its binary string representation.
    /// </summary>
    /// <param name="value">The Int32 to convert.</param>
    /// <returns>The binary string representation for an Int32 value.</returns>
    public String ConvertInt32ToBinaryString(Int32 value)
    {
            String pout = "";    
            int mask = 1 << 31;
    
            for (int n = 1; n <= 32; n++)
            {
                pout += (value & mask) == 0 ? "0" : "1";
                value <<= 1;
                if (n % 4 == 0)
                {pout += " ";}
            }
            
            return pout;
    }
