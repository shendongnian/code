            var p1 = new ProcessStartInfo
			{
				FileName = atomicParsleyFile,
				Arguments = atomicParsleyCommands,
				WindowStyle = ProcessWindowStyle.Hidden,
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardOutput = true
			};
            var proc = new Process { StartInfo = p1 };
			if (!proc.Start())
			{
				throw new ApplicationException("Starting atomic parsley failed!");
			}
                        /*Repeat above for second process here */
			Console.WriteLine(proc.StandardOutput.ReadToEnd());
			proc.WaitForExit(); //Run AtomicParsley and Wait for Exit
                        proc2.Kill();
