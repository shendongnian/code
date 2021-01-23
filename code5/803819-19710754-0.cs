    private static byte[] BinStringToBytes(string binary)
    {
        //make sure the string length is multiple of 32, if not pad it with zeroes
        var neededZeros = 32 - (binary.Length % 32);
        if (neededZeros > 0)
            binary = string.Concat(new string('0', neededZeros), binary);
        var blocks = binary.Length / 32;
        var binbytes = new byte[blocks * 4];
        for (var i = 0; i < blocks; i++)
        {
            var numstr = binary.Substring(i * 32, 32);
            var num = Convert.ToUInt32(numstr, 2);
            var bytes = BitConverter.GetBytes(num);
            Array.Copy(bytes, 0, binbytes, i * 4, 4);
        }
        return binbytes;
    }
