    static BigInteger RoughRoot(BigInteger x, int root)
    {
    	var bytes = x.ToByteArray();	// get binary representation
    	var bits = (bytes.Length - 1) * 8;	// get # bits in all but msb
    	// add # bits in msb
    	for (var msb = bytes[bytes.Length - 1]; msb != 0; msb >>= 1)
    		bits++;
    	var rtBits = bits / root + 1;	// # bits in the root
    	var rtBytes = rtBits / 8 + 1;	// # bytes in the root
    	// avoid making a negative number by adding an extra 0-byte if the high bit is set
    	var rtArray = new byte[rtBytes + (rtBits % 8 == 7 ? 1 : 0)];
    	// set the msb
    	rtArray[rtBytes - 1] = (byte)(1 << (rtBits % 8));
    	// make new BigInteger from array of bytes
    	return new BigInteger(rtArray);
    }
    
    public static BigInteger IntegerRoot(BigInteger n, int root)
    {
        var oldValue = new BigInteger(0);
        var newValue = RoughRoot(n, root);
        int i = 0;
        // I limited iterations to 100, but you may want way less
        while (BigInteger.Abs(newValue - oldValue) >= 1 && i < 100)
        {
            oldValue = newValue;
            newValue = ((root - 1) * oldValue 
                        + (n / BigInteger.Pow(oldValue, root - 1))) / root;
            i++;
        }
        return newValue;
    }
