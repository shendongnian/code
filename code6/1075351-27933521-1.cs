    using System;
    using System.IO;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
    	internal class Program
    	{
    		private static void Main(string[] args)
    		{
    			DirectoryInfo folderInfo = new DirectoryInfo("C:\\Windows");
    			FileInfo[] files = folderInfo.GetFiles();
    
    			Console.WriteLine("Enter a file size in Bytes i.e 500 bytes");
    			int userSize = int.Parse(Console.ReadLine());
    
    			FileInfo[] totalFiles = files.Where(x => x.Length == userSize).ToArray();
    
    		}
    	}
    }
