    binaryString = ToBitString(b);
    Console.Write(Convert.ToInt32(binaryString, 2))
    public string ToBitString(BitArray bits)
    {
        var sb = new StringBuilder();
    
        for (int i = 0; i < bits.Count; i++)
        {
            char c = bits[i] ? '1' : '0';
            sb.Append(c);
        }
    
        return sb.ToString();
    }
