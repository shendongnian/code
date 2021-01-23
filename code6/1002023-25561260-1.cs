    using System;
    using System.Collections;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string stringData = "AAAB"; // {000000} {000000} {000000} {000001}
    		byte[] byteData = Convert.FromBase64String(stringData); // {00000000}{00000000}{00000001}		
    		BitArray bitData = new BitArray(byteData.Reverse().ToArray()); // {000000000000000000000001}
    
    		for(var i=0; i < byteData.Length; i++){ //bitData.Length is 32
    			var bitValue = byteData[i];
    			Console.WriteLine("{0} {1}", i, bitValue);
    		}
    		
    		for(var i=0; i < bitData.Length; i++){ //bitData.Length is 32
    			var bitValue = bitData[i];
    			Console.WriteLine("{0} {1}", i, bitValue);
    		}
    	}
    }
