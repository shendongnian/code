    public bool GetValue(byte[] data, int position) 
    {
        var bytePos = position / 8;
        var bitPos = position % 8;
        return ((data[bytePos] & (1 << pitPos))!=0)
    }
    public long GetValue(byte[] data, int position, int length) 
    {
        if(length > 62)
        {
            throw new ArgumentException("not going to work properly with 63 bits if the first bit is 1");
        }
        long retv=0;
        for(int i = position;i<position+length;i++)
        {
             if(GetValue(data,i)
             {
                 retv |=1;
             }
             retv << 1;
        }
        retv >> 1;
    }
