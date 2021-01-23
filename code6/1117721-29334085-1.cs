    using System; 
    using System.Text;
    using System.Security.Cryptography;
    
    public class Program
    {
    	public static void Main()
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
    }
