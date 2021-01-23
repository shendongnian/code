     Process process = new Process();
     process.OutputDataReceived += new DataReceivedEventHandler(process_OutputDataReceived);     
     process.Exited += new EventHandler(process_Exited);
     process.ErrorDataReceived += new DataReceivedEventHandler(process_ErrorDataReceived); 
     process.Start();    
     process.BeginOutputReadLine();
     process.BeginErrorReadLine();    
     process.WaitForExit();
