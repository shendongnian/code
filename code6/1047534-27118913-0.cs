    public static int ParseBits(this byte[] bytes, int start, int length)
    {
        // Need to reverse the array to make it usable with BitArray
        Array.Reverse(bytes);
        var ba = new BitArray(bytes);
        var idx = 0;
        var shft = length - 1;
        // Iterate backwards through the bits and perform bitwise operations
        for (var i = start + length - 1; i >= 0; i--)
        {
            idx |= (Convert.ToInt32(ba.Get(i)) << shft);
            shft--;
        }
        return idx;
    }
