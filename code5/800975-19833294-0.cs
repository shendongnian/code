    Process myProcess = new Process();
    myProcess.EnableRaisingEvents = false;
    myProcess.StartInfo.FileName = "excel";
    myProcess.StartInfo.Arguments = String.Format(@"""{0}""", strFilePath);
    myProcess.Start();
