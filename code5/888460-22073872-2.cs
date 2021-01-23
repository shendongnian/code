    BitArrray truncateCopyBA(BitArray source, int size)
    {
        BitArray dest = new BitArray(size);
        
        for(int i = 0; i < size; ++i)
        {
            dest[i] = source[i];
        }
    
        return dest;
    }
    
    bool YourFunc(BitArray a, BitArray b)
    {
        BitArray one, two;
    
        if (a.Length < b.Length)
        {
            one = a;
            two = truncateCopyBA(b, a.Length);
        }
        else
        {
            one = truncateCopyBA(a, b.Length);
            two = b;
            
            // If you want to see which bits in both arrays are both ones, then use .And()
            // If you want to see which bits in both arrays are the same, use .Not(.Xor()).
            BitArray compareEq = a.And(b);
            bool anyBitsSame=false;
            for(int i = 0; i < compareEq.Length; ++i)
            {
                if(compareEq.Get(i))
                {
                    return true;
                }
            }
    
            return false
        }
    }
