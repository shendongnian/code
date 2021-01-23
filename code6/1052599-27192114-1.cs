    using System.IO;   
    
     class Program
    	{
    		static void Main(string[] args)
    		{
    			string line1;
    			string line2;
    
    			using (var fileout = new StreamWriter(@"C:\test\matched.txt"))
    			{
    				using (var file1 = new StreamReader(@"C:\test\file1.txt"))
    				{
    					while ((line1 = file1.ReadLine()) != null)
    					{
    						using (var file2 = new StreamReader(@"C:\test\file2.txt"))
    						{
    							while ((line2 = file2.ReadLine()) != null)
    							{
    								if (line1 == line2)
    								{
    									fileout.WriteLine(line1);
    								}
    							}
    						}
    					}
    				}
    			}
    		}
    	}
