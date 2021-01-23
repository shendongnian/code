    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication
    {
    	class Program
    	{
    		static void Main()
    		{
    			var tempFolder = System.IO.Path.GetTempFileName();
    			System.IO.File.Delete(tempFolder);
    
    			var proc = new Process();
    			proc.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
    			proc.StartInfo.Arguments = "--user-data-dir=\"" + tempFolder + "\" --disable-extensions http://google.com";
    
    			proc.Start();
    			proc.WaitForExit();
    			Console.WriteLine(proc.ExitCode.ToString());
    			proc.Close();
    		}
    	}
    }
