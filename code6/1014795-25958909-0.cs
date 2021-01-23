	byte[] data = new byte[s.Length/2];
	for(int i = 0; i < s.Length/2; ++i)
	{
		byte val = byte.Parse(s.Substring(i*2,2), System.Globalization.NumberStyles.HexNumber);
		data[i] = val;
	}
		
	foreach(byte bv in data)
	{
		Console.WriteLine(bv.ToString("X"));    
	}
