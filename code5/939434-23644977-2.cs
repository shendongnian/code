    public static BitArray ESieve(int upperLimit)
    {
        int sieveBound = (int)(upperLimit - 1);
        int upperSqrt = (int)Math.Sqrt(sieveBound);
        BitArray PrimeBits = new BitArray(sieveBound + 1, true);
        PrimeBits[0] = false;
        PrimeBits[1] = false;
        for(int j = 4; j <= sieveBound; j += 2)
        {
            PrimeBits[j] = false;
        }
        for(int i = 3; i <= upperSqrt; i += 2)
        {
            if(PrimeBits[i])
            {
                int inc = i * 2;
                for(int j = i * i; j <= sieveBound; j += inc)
                {
                    PrimeBits[j] = false;                       
                }
            }
        }
        return PrimeBits;
    }
