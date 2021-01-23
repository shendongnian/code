    private UInt16 CalcIPChecksum(byte[] buffer, ushort count,int offset)
    {
        ushort i =0;
        byte[] val = StatMethods.memcpy(ref buffer, offset, count);// get_byte_arr(buffer, count, offset);
                                                                   // public static byte[] memcpy(ref byte[] ar, int startposition, int offset)
        UInt32 sum_dw = 0;
        i = (ushort)(count >> 1);
        sum_dw = 0;
        int j = 0;
        while (i > 0)
        {
           UInt16 restored = BitConverter.ToUInt16(val, j);
           sum_dw += restored;
            String s = sum_dw.ToString("X");
           System.Diagnostics.Debug.WriteLine("Number: "+i+" -- "+"value:" + s);
           j += 2;
           i--;
        }
        var aa = count & 0x1;
        if (Convert.ToBoolean(aa))
        {
            byte restored = val[j];
            sum_dw += (byte)restored;
       
        }
        byte[] sum_wb = BitConverter.GetBytes(sum_dw);
        UInt16 sum_w0 = (UInt16)((UInt16)sum_wb[0] + (UInt32)(sum_wb[1]<<8));
        UInt16 sum_w1 = (UInt16)((UInt16)sum_wb[2] + (UInt32)(sum_wb[3] << 8));
        sum_dw = (UInt32)sum_w0 + (UInt32 )sum_w1; 
        sum_wb = BitConverter.GetBytes(sum_dw);
        sum_w0 = (UInt16)((UInt16)sum_wb[0] + (UInt32)(sum_wb[1] << 8));
        sum_w1 = (UInt16)((UInt16)sum_wb[2] + (UInt32)(sum_wb[3] << 8));
        sum_w0 += sum_w1;
     
        var reverse = ~(sum_w0);
        UInt16 ans = (UInt16)(~(sum_w0));
        System.Diagnostics.Debug.WriteLine("Asnwer: "+reverse);
        return (UInt16)reverse;
    }
