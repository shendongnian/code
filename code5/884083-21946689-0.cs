    using System;
    
    public class Test
    {
    	public static void Main()
    	{
    		System.Security.Cryptography.SHA256Managed hm = new System.Security.Cryptography.SHA256Managed();
    		byte[] hashValue = hm.ComputeHash(System.Text.Encoding.ASCII.GetBytes("abhinav"));
    		Console.WriteLine(System.BitConverter.ToString(hashValue).Replace("-", "").ToLower());
    	}
    }
