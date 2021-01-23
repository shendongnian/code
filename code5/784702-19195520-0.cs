    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.Diagnostics;
    using System.IO;
    namespace randomport
    {
    	class Core
    	{
    		public const int 
    			minval = 8001,
    			maxval = 8129;
            public static int[] usedPorts = new int[] { };
    		public static int 
    			chosenPort = 0,
    			tries = 0,
    			timeout = 10;
    		public static bool read = false;
    		public static void Main()
    		{
    			if(!read)
    			{
    				Read();
    				read = true;
    			}
    			RandGen();
    		}
    		public static void RandGen()
    		{
    			Process proc = null;
                string path = System.Environment.GetEnvironmentVariable("USERPROFILE");
    			Random rand = new Random();
    			if(tries < 129) chosenPort = rand.Next(minval, maxval);
    			else if(Directory.Exists(String.Concat(path, "\\desktop\\TerrariaServer\\filebin")))
    			{
    				proc.StartInfo.FileName                 = path+"\\TerrariaServer\\filebin\\sendservfull.bat";
    				proc.StartInfo.RedirectStandardError    = true;
    				proc.StartInfo.RedirectStandardOutput   = true;
    				proc.StartInfo.UseShellExecute          = false;
    				
    				proc.Start();
    
    				proc.WaitForExit
    					(
    						(timeout <= 0)
    						? int.MaxValue : timeout * 100 * 60
    					);
    			}
                else
                {
                    Directory.CreateDirectory(String.Concat(path, "\\TerrariaServer\\filebin"));
                /*  using (StreamWriter sw = File.CreateText(String.Concat(path, "\\TerrariaServer\\filebin\\sendservfull.bat"))
                    { 
                        sw.WriteLine
                    }
                    proc.StartInfo.FileName                 = @"path\TerrariaServer\filebin\sendservfull.bat";
    				proc.StartInfo.RedirectStandardError    = true;
    				proc.StartInfo.RedirectStandardOutput   = true;
    				proc.StartInfo.UseShellExecute          = false;
    				
    				proc.Start();
    
    				proc.WaitForExit
    					(
    						(timeout <= 0)
    						? int.MaxValue : timeout * 100 * 60
    					); */
                }
    			for(int i = 0; i < usedPorts.Length; i++)
    			{
    				if(chosenPort != usedPorts[i])
    				{
    					Write();
    				//	Application.Exit();
    				}
    				else
    				{
    					tries += 1;
    					return;
    				}
    			}
    		}
    		public static void Read()
    		{
                string path = System.Environment.GetEnvironmentVariable("USERPROFILE");
                if(Directory.Exists(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\activeports.bat")))
                {
    			    using (StreamReader sr = new StreamReader(String.Concat(path, "\\TerrariaServer\\filebin\\activeports.bat"))) 
    			    {
    				    string[] values = sr.ReadToEnd().Split(' ');
    				    usedPorts = new int[values.Length];//Initialize the array with the same length as values
    				    for (int i = 0; i < values.Length; i++)
    				    {
    					    int.TryParse(values[i], out usedPorts[i]);
    				    }
    			    }
                }
                else
                {
                    Directory.CreateDirectory(String.Concat(path, "\\TerrariaServer\\filebin"));
                    using (StreamWriter sw = File.CreateText(String.Concat(path, "\\TerrariaServer\\filebin\\activeports.bat"))) { }
                    using (StreamReader sr = new StreamReader(String.Concat(path, "\\TerrariaServer\\filebin\\activeports.bat"))) 
    			    {
    				    string[] values = sr.ReadToEnd().Split(' ');
    				    usedPorts = new int[values.Length];//Initialize the array with the same length as values
    				    for (int i = 0; i < values.Length; i++)
    				    {
    					    int.TryParse(values[i], out usedPorts[i]);
    				    }
    			    }
                }
    		}
    		public static void Write()
    		{
                string path = System.Environment.GetEnvironmentVariable("USERPROFILE");
                if (Directory.Exists(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\activeports.bat")))
                {
                    File.AppendAllText(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\activeports.bat"), "set port="+chosenPort+" ");
    //		        string cmdFile = Path.ChangeExtension(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\activeports.cmd"), ".cmd");
                }
                else
                {
                    Directory.CreateDirectory(String.Concat(path, "\\desktop\\TerrariaServer\\filebin"));
                    using (StreamWriter sw = File.CreateText(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\activeports.bat"))) { }
                    File.AppendAllText(String.Concat(path, "\\desktop\\TerrariaServer\\filebin\\activeports.bat"), "set port="+chosenPort+" ");
    //		        string pdfFile = Path.ChangeExtension(String.Concat(path, "\\TerrariaServer\\filebin\\activeports.bat"), ".cmd");
                }
    		}
    	}
    }
