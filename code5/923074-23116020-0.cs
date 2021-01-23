    		private static string _srvExePath;
            private static void UnpackFiles()
    		{
    			if (!Directory.Exists(_srvExePath))
    			{
    				Directory.CreateDirectory(_srvExePath);
    			}
    
    			Stream s1 = Assembly.GetExecutingAssembly().GetManifestResourceStream( assmblyname +"."+ resourcefile);
    			byte[] b1 = new byte[s1.Length];
    			s1.Read(b1, 0, (int)s1.Length);
    
    			File.WriteAllBytes(_srvExePath + file, b1);
    			//Console.WriteLine("unpacking: " + _srvExePath + file);
    		}
