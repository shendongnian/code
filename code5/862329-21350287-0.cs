    using System;
    using System.IO;
    using System.Collections.Generic;
    internal static class FileComparer
    {
    	public static void Compare(string directoryPath)
    	{			
    		if(!Directory.Exists(directoryPath))
    		{
    			return;
    		}
    		FileComparer.Compare(new DirectoryInfo(directoryPath));
    	}
    	private static void Compare(DirectoryInfo info)
    	{			
    		List<FileInfo> files = new List<FileInfo>(info.EnumerateFiles());
    		foreach(FileInfo file in files)
    		{
    			if(file.Exists)
    			{
    				byte[] array = File.ReadAllBytes(file.FullName);
    				foreach(FileInfo file2 in files)
    				{						
    					int length = array.Length;
    					byte[] array2 = File.ReadAllBytes(file2.FullName);
    					if(array2.Length == length)
    					{
    						bool flag = true;
    						for(int current = 0; current < length; current++)
    						{
    							if(array[current] != array2[current])
    							{
    								flag = false;
    								break;
    							}
    						}
    						if(flag)
    						{
    							file2.Delete();
    						}						
    					}
    				}
    			}
    		}
    	}
    }
