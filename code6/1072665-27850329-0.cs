        using System;
        using System.IO;
        using System.IO.MemoryMappedFiles;
        using System.Threading;
        namespace FileSharedMemory
        {
	        class MainClass
	        {
		        public static void Main (string[] args)
		        {
		
			        using (var mmf = MemoryMappedFile.CreateFromFile("/tmp/sharedfile", FileMode.OpenOrCreate, "/tmp/sharedfile"))
			        {
				        using (var stream = mmf.CreateViewStream ()) {
					        // 1. C program, filled memory-mapped file with the 'G' character (200 characters)
					        var data = stream.ReadByte ();
					        while (data != -1)
					        {
						        Console.WriteLine ((char)data);
						        data = stream.ReadByte ();
					         }
					         // 2. We write "Goose" at the beginning of memory-mapped file.
					         stream.Position = 0;
					         var buffer = new byte[] { 0x47, 0x6F, 0x6F, 0x73, 0x65 };
					         stream.Write (buffer, 0, 5);
					         Thread.Sleep (20000);
					         // 3. C program, filled memory-mapped file with the 'H' character (200 characters)
					         stream.Position = 0;
					         data = stream.ReadByte ();
					         while (data != -1)
					         {
						         Console.WriteLine ((char)data);
						         data = stream.ReadByte ();
					         }
				        }
			        }
		        }
	        }
        }
