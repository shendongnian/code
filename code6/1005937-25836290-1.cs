    using System;
    using System.IO;
    
    namespace Test
    {
    	class DirInformation
    	{
    		static public void DoSomething ()
    		{
    			string name = null;
    			name = "/home/mantosh/";
    			DirectoryInfo info = new DirectoryInfo (name);
    			bool dirExists = info.Exists;
    			Console.WriteLine(dirExists);
    		}
    
    		public static void Main (string[] args)
    		{
    			DoSomething();
    		}
    	}
    }
