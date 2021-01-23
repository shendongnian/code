        void RunFfmpeg()
        {
            ffmpegProcess = new Process
                {
                    EnableRaisingEvents = true,
                    StartInfo =
                        {
                            FileName = GetFfmpegPath(),
                            Arguments = ffmpegParams.ToString(),
                            UseShellExecute = false,
                        },
                };
            ffmpegProcess.Start();
            ffmpegProcess.BeginOutputReadLine();
            ffmpegProcess.WaitForExit();
        }
