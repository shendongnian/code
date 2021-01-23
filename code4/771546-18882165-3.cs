    public void convertWAVtoMP3(string wavfile)
            {
                //string lameEXE = @"C:\Users\Jibran\Desktop\MP3 Merger\bin\Debug\lame.exe";
                string lameEXE = Path.GetDirectoryName(Application.ExecutablePath) +"/lame.exe";
                string lameArgs = "-V2";
    
                string wavFile = wavfile;
                string mp3File = "mixed.mp3";
    
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo();
                process.StartInfo.FileName = lameEXE;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.Arguments = string.Format(
                    "{0} {1} {2}",
                    lameArgs,
                    wavFile,
                    mp3File);
    
                process.Start();
                process.WaitForExit();
    
                int exitCode = process.ExitCode;
    }
