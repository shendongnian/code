    using System;
    using System.Globalization;
    					
    public class Program
    {
    	public static void Main()
    	{
    	
    		string MYBytes = "{ 0x4D, 0x5A, 0x90 }";
    		
    		string[] hexParts = MYBytes.Split(new char[] { ',', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
    		
    		byte[] bytes = new byte[hexParts.Length];
    		
    		for(int i = 0; i < hexParts.Length; i++)
    			bytes[i] = Byte.Parse(hexParts[i].Substring(3), NumberStyles.HexNumber);
    		
    		
    		foreach(byte b in bytes)
    			Console.WriteLine("{0:X2}", b);
    	}
    }
