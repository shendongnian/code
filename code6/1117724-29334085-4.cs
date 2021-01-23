    using System;
    using System.Text;
    using System.Security.Cryptography;
    
    public class Program
    {
    	public static void Main()
    	{
    		UseAHash();
    		UseTime();
    	}
    
    	public static void UseAHash()
    	{
    		var primaryKey = 123345;
    		HashAlgorithm algorithm = SHA1.Create();
    		var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(primaryKey.ToString()));
    		StringBuilder sb = new StringBuilder();
    		for (var i = 0; i < 6; ++i)
    		{
    			sb.Append(hash[i].ToString("X2"));
    		}
    
    		Console.WriteLine(sb);
    	}
    
    	public static void UseTime()
    	{
    		StringBuilder builder = new StringBuilder();
    		
    		builder.Append(DateTime.Now.DayOfYear.ToString("D3"));
    		builder.Append(DateTime.Now.Hour.ToString("D2"));
    		builder.Append(DateTime.Now.Minute.ToString("D2"));
    		builder.Append(DateTime.Now.Second.ToString("D2"));
    		builder.Append(DateTime.Now.Millisecond.ToString("D3"));
    		
    		Console.WriteLine("Length: " + builder.Length);
    		Console.WriteLine("Result: " + builder);
    	}
    }
